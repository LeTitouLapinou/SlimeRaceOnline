using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class Scr_PlayerCursorBehavior : NetworkBehaviour
{
    [SerializeField] private RectTransform cursorRectTransform;

    private Image cursorImage;
    private IHoverable currentlyHovered;

    private NetworkVariable<Vector2> cursorPosition = new NetworkVariable<Vector2>(writePerm: NetworkVariableWritePermission.Owner);
    private NetworkVariable<Color> cursorColor = new NetworkVariable<Color>(writePerm: NetworkVariableWritePermission.Owner);
    

    public override void OnNetworkSpawn()
    {
        Canvas uiCanvas = GameObject.FindGameObjectWithTag("CursorCanvas")?.GetComponent<Canvas>();
        if (uiCanvas != null)
        {
            transform.SetParent(uiCanvas.transform, false);

            
        }

        cursorRectTransform = GetComponent<RectTransform>();  // Get the RectTransform of the cursorImage
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Set initial position to zero

        cursorImage = GetComponent<Image>();
        // Set initial color based on client/server (one-time)
        if (IsOwner)
        {
            if (IsServer)
            {
                cursorColor.Value = Color.blue;
            }
            else
            {
                cursorColor.Value = Color.red;
            }
        }

        // Apply synced color (this runs on all clients)
        cursorColor.OnValueChanged += (prev, current) =>
        {
            cursorImage.color = current;
        };

        // Apply color immediately
        cursorImage.color = cursorColor.Value;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            //Normalize mouse position in screen 
            Vector2 mousePos = Input.mousePosition;
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            cursorPosition.Value = new Vector2(mousePos.x / screenSize.x, mousePos.y / screenSize.y);


            //Raycast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                var parent = hit.collider.transform.parent;

                IHoverable hoverable = parent.GetComponentInChildren<IHoverable>();

                if (hoverable != null)
                {
                    if (hoverable != currentlyHovered)
                    {
                        currentlyHovered?.OnHoverExit();
                        hoverable.OnHoverEnter();
                        currentlyHovered = hoverable;
                    }
                }
                else
                {
                    // Hit something, but not hoverable — exit hover
                    currentlyHovered?.OnHoverExit();
                    currentlyHovered = null;
                }

                if (Input.GetMouseButtonDown(0)) // Left click
                {
                    var clickable = parent.GetComponentInChildren<IClickable>();
                    clickable?.OnClick(); 
                }
            }
            else
            {
                // Hit nothing — exit hover
                currentlyHovered?.OnHoverExit();
                currentlyHovered = null;
            }

            
        }

        //Sync for all clients
        if (cursorRectTransform != null && cursorRectTransform.parent is RectTransform parentRect)
        {
            Vector2 size = parentRect.rect.size;

            // Adjust for pivot
            Vector2 anchoredPos = new Vector2(
                (cursorPosition.Value.x * size.x) - (size.x * cursorRectTransform.pivot.x),
                (cursorPosition.Value.y * size.y) - (size.y * cursorRectTransform.pivot.y)
            );

            cursorRectTransform.anchoredPosition = anchoredPos;
        }



    }
}

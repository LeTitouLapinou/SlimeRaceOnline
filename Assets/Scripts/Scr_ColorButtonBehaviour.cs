using UnityEngine;
using UnityEngine.UI;

public class Scr_ColorButtonBehaviour : MonoBehaviour
{
    private float alphaThreshold = 0.1f;

    public bool buttonClicked = false;
    public Color buttonColor;

    private Scr_ColorButtonManager buttonManager;
   
    [SerializeField] private Button button;
    [SerializeField] private Image buttonImage;
    [SerializeField] private RectTransform buttonOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        buttonImage.alphaHitTestMinimumThreshold = alphaThreshold;

        buttonManager = FindFirstObjectByType<Scr_ColorButtonManager>(); //Find the buttonManager in the scene

        //Add the click listener
        button.onClick.AddListener(OnButtonClicked);

        buttonImage.color = buttonColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        buttonManager.OnButtonClick(this);
    }

    public void OutlineAppear()
    {
        buttonOutline.gameObject.SetActive(true);
    }
    public void OutlineDisappear()
    {
        buttonOutline.gameObject.SetActive(false);
    }

}

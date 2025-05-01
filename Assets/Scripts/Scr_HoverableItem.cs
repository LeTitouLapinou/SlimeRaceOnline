using UnityEngine;

public class Scr_HoverableItem : MonoBehaviour
{

    [SerializeField] private bool clickable = false;

    public void OnHoverEnter()
    {
        Debug.Log($"{gameObject.name} was hovered over.");

        // Send message to all components on the GameObject
        //SendMessage("OnHoverEnter", SendMessageOptions.DontRequireReceiver);
    }

    public void OnHoverExit()
    {
        Debug.Log($"{gameObject.name} is no longer hovered.");

        // Send message to all components on the GameObject
        //SendMessage("OnHoverExit", SendMessageOptions.DontRequireReceiver);
    }

    public void OnClick()
    {
        if (!clickable) return;

        Debug.Log($"{gameObject.name} clicked.");

        // Send message to all components on the GameObject
        //SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Scr_ColorButtonManager : MonoBehaviour
{
    public Scr_ColorButtonBehaviour lastClickedButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(Scr_ColorButtonBehaviour buttonCaller)
    {
        if (lastClickedButton != null)
        {
            lastClickedButton.OutlineDisappear();
        }

        lastClickedButton = buttonCaller;  // Store the clicked button's color
        lastClickedButton.OutlineAppear();
        Debug.Log("Last clicked color: " + lastClickedButton);
    }

}

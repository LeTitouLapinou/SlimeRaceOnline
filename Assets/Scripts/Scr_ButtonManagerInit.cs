using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Scr_ButtonManagerInit : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private SO_ListOfColors listOfColors; //Get list of color scriptable object


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var tempColorList = new List<Color>(listOfColors.colors); //On recupere la liste des couleurs du ScriptableObject ListOfColors

        for (int i = 0; i < 4; i++)
        {
            GameObject instantiatedButton = Instantiate(buttonPrefab, transform);
            instantiatedButton.GetComponent<Scr_ColorButtonBehaviour>().buttonColor = tempColorList[i];
            instantiatedButton.name = "Button_" + i; //Name the button
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

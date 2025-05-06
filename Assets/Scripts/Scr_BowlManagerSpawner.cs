using System.Collections.Generic;
using UnityEngine;

public class Scr_BowlManagerSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bowlPrefab;
    [SerializeField] private SO_ListOfColors listOfColors; //Get list of color scriptable object

    [SerializeField] private int buttonCount = 4;
    [SerializeField] private float spacing = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LayoutBowls();
    }

    void LayoutBowls()
    {
        var tempColorList = new List<Color>(listOfColors.colors); //On recupere la liste des couleurs du ScriptableObject ListOfColors
        Vector3 startPosition = transform.position;


        for (int i = 0; i < buttonCount; i++)
        {
            GameObject bowl = Instantiate(bowlPrefab, transform);
            bowl.transform.position = startPosition + new Vector3(0, 0 , i * spacing);
            bowl.name = "Bowl_" + i; //Name the button

            var bowlBehaviour = bowl.GetComponent<Scr_BowlBehaviour>();
            bowlBehaviour.bowlColor = tempColorList[i];

            Renderer renderer = bowl.GetComponentInChildren<Renderer>();
            Material uniqueMat = new Material(renderer.material); //make a copy
            bowlBehaviour.SetMaterial(uniqueMat); //assign to script

            
        }
    }
}



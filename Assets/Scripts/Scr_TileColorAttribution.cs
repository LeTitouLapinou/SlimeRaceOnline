using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class Scr_TileColorAttribution : MonoBehaviour
{
    public SO_ListOfColors listOfColors;

    private List<Scr_TileLogic> FourTileList = new List<Scr_TileLogic>();
    private List<Scr_TileLogic> ThreeTileList = new List<Scr_TileLogic>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GetTilesWithTag("4Tile", FourTileList);
        SetTilesColor(FourTileList);
        GetTilesWithTag("3Tile", ThreeTileList);
        SetTilesColor(ThreeTileList);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetTilesWithTag(string tag, List<Scr_TileLogic> listToAppend)
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag(tag))
            {
                listToAppend.Add(child.GetComponent<Scr_TileLogic>());
            }
        }
    }

    void SetTilesColor(List<Scr_TileLogic> tileList)
    {
        var tempColorList = new List<Color>(listOfColors.colors); //On recupere la liste des couleurs du ScriptableObject ListOfColors
        
        foreach (var tile in tileList)
        {
            var index = Random.Range(0, tempColorList.Count);
            Color selectedColor = tempColorList[index]; //Random color from tempColorList
            tile.tileColor = selectedColor;
            tempColorList.RemoveAt(index); //Remove the color picked from the list

            if (tempColorList.Count == 0) //Break if color list is empty
                break;
        }
        
    }
}

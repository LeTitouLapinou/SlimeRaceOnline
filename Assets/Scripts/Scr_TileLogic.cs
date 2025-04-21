using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
public class Scr_TileLogic : MonoBehaviour
{
    public Color tileColor;

    private MeshRenderer meshRendererRef;

    private void Awake()
    {
        meshRendererRef = transform.Find("Mesh").GetComponent<MeshRenderer>(); //Find the child named "Mesh" and get its mesh component
        ChangeTileColor();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeTileColor()
    {
        meshRendererRef.material.color = tileColor;
    }
}

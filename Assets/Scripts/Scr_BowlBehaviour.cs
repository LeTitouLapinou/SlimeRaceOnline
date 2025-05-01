using Unity.VisualScripting;
using UnityEngine;

public class Scr_BowlBehaviour : MonoBehaviour
{
    public Color bowlColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer bowlRenderer = GetComponentInChildren<Renderer>();

        if (bowlRenderer != null)
        {
            bowlRenderer.material.color = bowlColor;
        }
        else
        {
            Debug.LogWarning("No Renderer found on bowl or its children.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

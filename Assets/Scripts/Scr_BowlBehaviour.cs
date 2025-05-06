using UnityEngine;
using UnityEngine.Rendering;

public class Scr_BowlBehaviour : MonoBehaviour, IClickable, IHoverable
{
    public Color bowlColor;

    private Renderer bowlRenderer;
    private Material instanceMaterial;

    private static readonly int BaseColorID = Shader.PropertyToID("_BaseColor");
    private static readonly int EmissionColorID = Shader.PropertyToID("_EmissionColor");


    void Awake()
    {
        bowlRenderer = GetComponentInChildren<Renderer>();

    }

    void Start()
    {
        instanceMaterial.SetColor(BaseColorID, bowlColor);
        instanceMaterial.SetColor(EmissionColorID, Color.black); // start with no emission
    }


    public void SetMaterial(Material mat)
    {
        instanceMaterial = mat;
        instanceMaterial.EnableKeyword("_EMISSION");

        if (bowlRenderer != null)
        {
            bowlRenderer.material = instanceMaterial;
        }
    }


    public void OnClick()
    {
        Debug.Log("Clicked");
        
    }

    public void OnHoverEnter()
    {
        Debug.Log(gameObject.name + " Hovered");

        if (instanceMaterial != null)
        {
            instanceMaterial.SetColor(BaseColorID, bowlColor);
            instanceMaterial.SetColor(EmissionColorID, bowlColor * 2f);
        }
    }

    public void OnHoverExit()
    {
        Debug.Log("Hover left");

        if (instanceMaterial != null)
        {
            instanceMaterial.SetColor(BaseColorID, bowlColor);
            instanceMaterial.SetColor(EmissionColorID, Color.black);
        }
    }
}

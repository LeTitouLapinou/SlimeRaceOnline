using System.Collections;
using UnityEngine;

public class Scr_PlankManager : MonoBehaviour
{
    public float planksGap = 1f;
    public int planksNumber = 5;

    public GameObject plankPrefab;

    private float plankSize = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rendererList = plankPrefab.GetComponentsInChildren<Renderer>(); //Get a list of all the renderers of the children
        foreach (Renderer renderer in rendererList)
        {
            if (renderer.bounds.size.z>plankSize)
            {
                plankSize = renderer.bounds.size.z;
            }
        }

        StartCoroutine(CoUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoUpdate()
    {
        var nextPosition = 0f;

        for (int i = 0; i < planksNumber; i++)
        {
            Instantiate(plankPrefab, new Vector3(0, 0, nextPosition), transform.rotation); //Instantiate each plank with the desired offset
            nextPosition += (plankSize + planksGap); //Calculate position of the next plank based on the size of the prefab + gap wanted
            yield return new WaitForSeconds(0.2f); // waits half a second between each plank
        }

        yield return null;
    }
}

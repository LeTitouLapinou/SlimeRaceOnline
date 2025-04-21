using UnityEngine;

public class Scr_PlankRotation : MonoBehaviour
{

    //public bool flipped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            transform.eulerAngles = new Vector3(180,0,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

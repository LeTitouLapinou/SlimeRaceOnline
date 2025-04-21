using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Scr_PlankSpawnAnimation : MonoBehaviour
{
    public float duration = 1.0f;
    public SO_AnimationCurve SO_curve;
    public float startY = 5f;

    private AnimationCurve curve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curve = SO_curve.animCurve; //Assign curve from animCurve
        StartCoroutine(CoUpdate()); //Start Coroutine
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoUpdate()
    {
        
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration; // Normalize time
            float yPos = Mathf.LerpUnclamped(startY, 0f, curve.Evaluate(t));  // Interpolate based on the curve

            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);  // Update position

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

}

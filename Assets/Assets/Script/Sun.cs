using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public Transform pivotPoint;
    public Light Sun;
    public Material skyMaterial;
    public List<Material> skyColors;
    public float rotationSpeed = 10f;
    public float transitionSpeed = 0.5f; // seconds per color fade

    private int currentIndex = 0;
    private int nextIndex = 1;
    private float t = 0f;

    void Update()
    {
        // Rotate the sun
        if (pivotPoint && Sun)
            Sun.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);

        // Smooth color transition
        if (skyColors.Count >= 2 && skyMaterial)
        {
            Color from = skyColors[currentIndex].color;
            Color to = skyColors[nextIndex].color;

            t += Time.deltaTime / transitionSpeed;
            Color lerpedColor = Color.Lerp(from, to, t);

            skyMaterial.color = lerpedColor;
            Sun.color = lerpedColor;

            if (t >= 1f)
            {
                t = 0f;
                currentIndex = nextIndex;
                nextIndex = (nextIndex + 1) % skyColors.Count;
            }
        }
    }
}

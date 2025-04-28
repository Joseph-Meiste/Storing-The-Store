using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public Transform pivotPoint;
    public Light Sun;
    public Material skyMaterial;
    public List<Material> skyColors;
    public float rotationSpeed = 10f;
    public float transitionSpeed = 0.5f;

    private int currentIndex = 0;
    private int nextIndex = 1;
    private float t = 0f;

    void Update()
    {
        RotateSun();
        UpdateSkyAndSunColor();
    }

    private void RotateSun()
    {
        if (pivotPoint != null && Sun != null)
        {
            Sun.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    private void UpdateSkyAndSunColor()
    {
        Color from = skyColors[currentIndex].GetColor("_Color");
        Color to = skyColors[nextIndex].GetColor("_Color");

        t += Time.deltaTime / transitionSpeed;
        Color lerpedColor = Color.Lerp(from, to, t);

        skyMaterial.SetColor("_Color", lerpedColor);
        Sun.color = lerpedColor;

        if (t >= 1f)
        {
            t = 0f;
            currentIndex = nextIndex;
            nextIndex = (nextIndex + 1) % skyColors.Count;
        }
    }
}

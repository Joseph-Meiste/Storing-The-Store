using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

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

    public float requiredProgress = 0f;

    ValueHolder holder; 

    private void Awake()
    {
        holder = GameObject.Find("Map").GetComponent<ValueHolder>();
    }

    void Update()
    {
        requiredProgress = holder.Precent();

        RotateSun();

        if (CanTransition())
        {
            UpdateSkyAndSunColor();
        }
    }

    private void RotateSun()
    {
        if (pivotPoint != null && Sun != null)
        {
            Sun.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    private bool CanTransition()
    {
        if (nextIndex <= 2)
            return true;

        return Mathf.Approximately(requiredProgress, 0.2f) ||
               Mathf.Approximately(requiredProgress, 0.4f) ||
               Mathf.Approximately(requiredProgress, 0.6f) ||
               Mathf.Approximately(requiredProgress, 1f);
    }

    private void UpdateSkyAndSunColor()
    {
        if (skyColors.Count < 2) return;

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

            if (nextIndex < skyColors.Count - 1)
                nextIndex++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public Transform pivotPoint;
    public Light Sun;
    public int rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Sun.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

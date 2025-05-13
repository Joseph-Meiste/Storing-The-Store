using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public List<GameObject> Walls;
    public Camera SecurityCam;
    public GameObject Security;
    public Transform pivotPoint;
    public bool RotationRight;

    public float rotationSpeed = 125f;
    public int wallIndex = 0;

    private void SwitchAngle(int angle)
    {
        SecurityCam.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime * angle);
    }

    private void Update()
    {
        WallDisplay();

        float fallbackSpeed = rotationSpeed * 0.2f;

        if (RotationRight)
        {
            SecurityCam.transform.RotateAround(pivotPoint.position, Vector3.up, -fallbackSpeed * Time.deltaTime);
        }
        else
        {
            SecurityCam.transform.RotateAround(pivotPoint.position, Vector3.up, fallbackSpeed * Time.deltaTime);
        }
    }

    private void WallDisplay()
    {
            Vector3 CamAngle = SecurityCam.transform.eulerAngles;

            if (CamAngle.y >= 180f && CamAngle.y < 270f)
            {
                wallIndex = 1;
            }
            else if (CamAngle.y >= 90f && CamAngle.y < 180f)
            {
                wallIndex = 2;
            }
            else if (CamAngle.y >= 0f && CamAngle.y < 90f)
            {
                wallIndex = 3;
            }
            else if (CamAngle.y >= 270f && CamAngle.y < 360f)
            {
                wallIndex = 4;
            }

            for (int i = 0; i < Walls.Count; i++)
            {
                Walls[i].SetActive(false);
            }

            if (wallIndex > 0 && wallIndex <= Walls.Count)
            {
                Walls[wallIndex - 1].SetActive(true);
        }
    }
}

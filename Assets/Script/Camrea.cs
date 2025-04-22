using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    public List<GameObject> Walls;
    public Camera SecurityCam;
    public Camera Player;
    public Transform pivotPoint;
    public TimeTracker Timer;

    public float rotationSpeed = 80f;
    public int wallIndex = 0;

    private void SwitchAngle(int angle)
    {
        SecurityCam.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime * angle);
    }

    private void Update()
    {
        WallDisplay();

        if (Timer.isDay)
        {
            if (!Player.gameObject.activeSelf)
            {
                SecurityCam.gameObject.SetActive(true);
                Player.gameObject.SetActive(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                SwitchAngle(-1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SwitchAngle(1);
            }
        }
        else
        {
            if (!Player.gameObject.activeSelf)
            {
                Player.gameObject.SetActive(true);
                SecurityCam.gameObject.SetActive(false);
            }
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
        else if ((CamAngle.y >= 0f && CamAngle.y < 90f) || (CamAngle.y >= 360f && CamAngle.y <= 400f))
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
            Walls[wallIndex-1].SetActive(true);
        }
    }
}

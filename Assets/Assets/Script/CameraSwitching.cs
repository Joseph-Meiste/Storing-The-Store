using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public List<GameObject> Walls;
    public Camera SecurityCam;
    public GameObject Security;
    public GameObject Player;
    public Transform pivotPoint;
    public GameObject roof;
    public bool RotationRight;

    ValueHolder Holder;

    public float rotationSpeed = 80f;
    public int wallIndex = 0;

    private void Awake()
    {
        Holder = FindObjectOfType<ValueHolder>();
    }

    private void SwitchAngle(int angle)
    {
        SecurityCam.transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime * angle);
    }

    private void Update()
    {
        WallDisplay();

        if (Holder != null && Holder.isDay)
        {
            if (Security != null && Player != null)
            {
                Security.SetActive(true);
                Player.SetActive(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                SwitchAngle(-1);
                RotationRight = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SwitchAngle(1);
                RotationRight = false;
            }
            else
            {
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
        }
        else
        {
            if (Security != null && Player != null)
            {
                Security.SetActive(false);
                Player.SetActive(true);
            }
        }
    }

    private void WallDisplay()
    {
        if (Holder.isDay)
        {
            roof.SetActive(false);
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
        else if(!Holder.isDay)
        {
            Walls[0].SetActive(false);
            Walls[1].SetActive(false);
            Walls[2].SetActive(false);
            Walls[3].SetActive(false);

            roof.SetActive(true);
            Walls[0].SetActive(true);
            Walls[2].SetActive(true);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    public GameObject Platform;
    public List<GameObject> Walls;
    public Camera SecurityCam1;
    public Camera SecurityCam2;
    public Camera Player;

    public bool isDay = true;

    public float CoolDown = 0f;
    public float SetCoolDown = 1f;

    private int wallIndex = 0;

    private void SwitchAngle(int angle)
    {
        wallIndex = (wallIndex + angle + Walls.Count) % Walls.Count;

        for (int i = 0; i < Walls.Count; i++)
        {
            Walls[i].SetActive(i == wallIndex);
        }

        Platform.transform.Rotate(_rotation * angle);

        bool cam1Active = SecurityCam1.gameObject.activeSelf;
        SecurityCam1.gameObject.SetActive(!cam1Active);
        SecurityCam2.gameObject.SetActive(cam1Active);

        CoolDown = SetCoolDown;
    }

    private void Update()
    {
        if (CoolDown > 0f)
        {
            CoolDown -= Time.deltaTime;
        }

        if (isDay)
        {
            if (!Player.gameObject.activeSelf)
            {
                SecurityCam1.gameObject.SetActive(true);
                SecurityCam2.gameObject.SetActive(false);
                Player.gameObject.SetActive(false);
            }

            if (CoolDown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SwitchAngle(-1);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    SwitchAngle(1);
                }
            }
        }
        else
        {
            if (!Player.gameObject.activeSelf)
            {
                Player.gameObject.SetActive(true);
                SecurityCam1.gameObject.SetActive(false);
                SecurityCam2.gameObject.SetActive(false);
            }
        }
    }
}

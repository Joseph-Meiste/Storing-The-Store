using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public List<Camera> Cameras = new List<Camera>(); 
    public GameObject cameraGroup;
    public bool isDay = true;

    private int currentIndex = 0;

    private void Start()
    {
        ActivateCamera(currentIndex);
    }

    private void Update()
    {
        if (isDay)
          {
          if (Input.GetKeyDown(KeyCode.D))
          {
              currentIndex = (currentIndex + 1) % Cameras.Count;
              ActivateCamera(currentIndex);
          }
          if (Input.GetKeyDown(KeyCode.A))
          {
              currentIndex = (currentIndex - 1 + Cameras.Count) % Cameras.Count;
              ActivateCamera(currentIndex);
          }
        }
    }

    private void ActivateCamera(int index)
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            Cameras[i].gameObject.SetActive(i == index);
        }
    }
}

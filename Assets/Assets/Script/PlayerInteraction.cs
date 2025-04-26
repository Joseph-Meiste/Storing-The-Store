using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                CheckOverLoad shelf = hit.collider.GetComponent<CheckOverLoad>();
                if (shelf != null)
                {
                    shelf.Restock();
                }
            }
        }
    }
}

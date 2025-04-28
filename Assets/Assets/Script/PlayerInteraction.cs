using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float lookRange = 5f;
    public Camera playerCamera;
    public Text displayText;

    private ShelfInteraction currentItem;

    private void Update()
    {
        LookAtObjects();
    }

    private void LookAtObjects()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, lookRange))
        {
            ShelfInteraction item = hit.collider.GetComponent<ShelfInteraction>();

            if (item != null)
            {
                displayText.text = item.itemName;

                if (currentItem != item)
                {
                    if (currentItem != null)
                    {
                        currentItem.interaction = false;
                    }

                    currentItem = item;
                    currentItem.interaction = true;
                }
            }
        }
        else
        {
            if (currentItem != null)
            {
                displayText.text = "";
                currentItem.interaction = false;
                currentItem = null; 
            }
        }
    }
}

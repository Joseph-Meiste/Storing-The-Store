using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    public float lookRange = 5f;
    public string ItemCount;
    public Camera playerCamera;
    public Text ItemNameText;
    public Text ItemCountText;
    public GameObject pannel;

    private ShelfInteraction currentItem;

    private void Start()
    {
        pannel.SetActive(false);
    }

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
                pannel.SetActive(true);
                ItemNameText.text = item.Message;
                ItemCountText.text = "(" + item.itemsLeft + "/" + item.maxitem + ")";

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
                pannel.SetActive(false);
                ItemNameText.text = "";
                ItemCountText.text = "";
                currentItem.interaction = false;
                currentItem = null; 
            }
        }
    }
}

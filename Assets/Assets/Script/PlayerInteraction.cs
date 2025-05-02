using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float lookRange = 5f;
    public Camera playerCamera;
    public Text ItemNameText;
    public Text ItemCountText;
    public GameObject pannel;

    private IInteractable currentItem;

    private void Start()
    {
        pannel.SetActive(false);
    }

    private void Update()
    {
        LookAtObjects();

        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            currentItem.Interact();
        }
    }

    private void LookAtObjects()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, lookRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (currentItem != interactable)
                {
                    if (currentItem != null)
                        currentItem.interaction = false;

                    currentItem = interactable;
                    currentItem.interaction = true;
                }

                // Optional UI update for shelves
                if (interactable is ShelfInteraction shelf)
                {
                    pannel.SetActive(true);
                    ItemNameText.text = shelf.Message;
                    ItemCountText.text = "(" + shelf.itemsLeft + "/" + shelf.maxitem + ")";
                }
            }
        }
        else
        {
            if (currentItem != null)
            {
                currentItem.interaction = false;
                currentItem = null;

                pannel.SetActive(false);
                ItemNameText.text = "";
                ItemCountText.text = "";
            }
        }
    }
}

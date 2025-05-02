using UnityEngine;

public class ShelfInteraction : MonoBehaviour, IInteractable
{
    public string itemName;
    public string Message;
    public bool interaction { get; set; }
    public int itemsLeft;
    public int maxitem;

    private CheckOverLoad checkOverLoad;

    private void Awake()
    {
        checkOverLoad = GameObject.Find(itemName).GetComponent<CheckOverLoad>();
        itemsLeft = checkOverLoad.ItemsLeft;
        maxitem = checkOverLoad.Reset;
    }

    public void Interact()
    {
        checkOverLoad.Restock();
        UpdateItemLeft();
    }

    public void UpdateItemLeft()
    {
        itemsLeft = checkOverLoad.ItemsLeft;
    }
}

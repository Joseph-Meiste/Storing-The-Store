using UnityEngine;

public class DemoShelf : MonoBehaviour, IInteractable
{
    public string itemName;
    public string Message;
    public bool interaction { get; set; }
    public int itemsLeft;
    public int maxitem;

    private TestCheckOverLoad checkOverLoad;

    private void Awake()
    {
        checkOverLoad = GameObject.Find(itemName).GetComponent<TestCheckOverLoad>();
        itemsLeft = checkOverLoad.ItemsLeft - 4;
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

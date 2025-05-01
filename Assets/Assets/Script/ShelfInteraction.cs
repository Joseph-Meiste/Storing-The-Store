using UnityEngine;

public class ShelfInteraction : MonoBehaviour
{
    public string itemName;
    public string Message;
    public bool interaction;
    public int itemsLeft;
    public int maxitem;

    private CheckOverLoad checkOverLoad;

    private void Awake()
    {
        checkOverLoad = GameObject.Find(itemName).GetComponent<CheckOverLoad>();
        itemsLeft = checkOverLoad.ItemsLeft;
        maxitem = checkOverLoad.Reset;
    }

    private void Update()
    {
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            checkOverLoad.Restock();
            UpdateItemLeft();
        }
    }
    public void UpdateItemLeft()
    {
        itemsLeft = checkOverLoad.ItemsLeft;
    }
}

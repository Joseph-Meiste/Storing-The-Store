using UnityEngine;

public class ShelfInteraction : MonoBehaviour
{
    public string itemName;
    public string Message;
    public bool interaction; 

    private CheckOverLoad checkOverLoad;

    private void Awake()
    {
        checkOverLoad = GameObject.Find(itemName).GetComponent<CheckOverLoad>();
    }

    private void Update()
    {
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            checkOverLoad.Restock();
        }
    }
}

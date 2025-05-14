using UnityEngine;
using System.Collections;

public class TestCheckOverLoad : MonoBehaviour
{
    public int UsesLeft;
    public int ItemsLeft;
    public int Reset;

    public GameObject shelf;

    ShelfInteraction update;
    TestVisualUpdate visual;

    private void Awake()
    {
        update = shelf.GetComponent<ShelfInteraction>();
        visual = shelf.GetComponent<TestVisualUpdate>();
    }

    public bool Verify()
    {
        if (UsesLeft > 0)
        {
            UsesLeft--;
            return true;
        }
        return false;
    }

    public bool NeedItem()
    {
        if (ItemsLeft > 0)
        {
            ItemsLeft--;
            UsesLeft--;
            return true;
        }
        return false;
    }

    public bool TakeItem()
    {
        if (ItemsLeft > 0)
        {
            ItemsLeft--;
            update.UpdateItemLeft();

            StartCoroutine(DelayedShelfUpdate());

            return true;
        }
        return false;
    }

    private IEnumerator DelayedShelfUpdate()
    {
        yield return new WaitForSeconds(2f);
        visual.ShelfUpdate();
    }

    public void Restock()
    {
        ItemsLeft = Reset;
        visual.ResetShelf();
    }
}

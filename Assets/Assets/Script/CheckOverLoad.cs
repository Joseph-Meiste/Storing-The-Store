using UnityEngine;

public class CheckOverLoad : MonoBehaviour
{
    public int UsesLeft;
    public int ItemsLeft;
    public int Reset;

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
            return true;
        }
        return false;
    }

    public void Restock()
    {
        ItemsLeft = Reset;
    }
}

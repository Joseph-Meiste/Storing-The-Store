using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CheckOverLoad : MonoBehaviour
{
    public int UsesLeft;
    public int ItemsLeft;

    private void Awake()
    {
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
            return true;
        }
        return false;
    }
}
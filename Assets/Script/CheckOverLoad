using System.Collections.Generic;
using UnityEngine;

public class CheckOverLoad : MonoBehaviour
{
    private static Dictionary<string, int> itemStock = new Dictionary<string, int>();

    public bool TryUseItem(string item)
    {
        if (!itemStock.ContainsKey(item))
            itemStock[item] = 6;

        if (itemStock[item] > 0)
        {
            itemStock[item]--;
            Debug.Log($"{item} used. Remaining stock: {itemStock[item]}");
            return true;
        }

        Debug.Log($"{item} out of stock!");
        return false;
    }

    public int GetStock(string item)
    {
        return itemStock.ContainsKey(item) ? itemStock[item] : 6;
    }
}
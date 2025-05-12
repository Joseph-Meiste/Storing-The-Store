using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualUpdate : MonoBehaviour
{
    public GameObject[] itemsOnShelf;
    public int removeCount;

    public void ShelfUpdate()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < itemsOnShelf.Length; i++)
        {
            indices.Add(i);
        }

        for (int i = 0; i < indices.Count; i++)
        {
            int randomIndex = Random.Range(i, indices.Count);
            (indices[i], indices[randomIndex]) = (indices[randomIndex], indices[i]);
        }

        for (int i = 0; i < removeCount; i++)
        {
            int indexToDisable = indices[i];
            itemsOnShelf[indexToDisable].SetActive(false);
        }
    }

    public void ResetShelf()
    {
        foreach (GameObject item in itemsOnShelf)
        {
            item.SetActive(true);
        }
    }
}

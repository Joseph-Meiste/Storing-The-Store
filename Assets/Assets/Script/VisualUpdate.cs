using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualUpdate : MonoBehaviour
{
    public GameObject[] itemsOnShelf;
    public int removeCount;

    public void ShelfUpdate()
    {
        List<int> activeIndices = new List<int>();
        for (int i = 0; i < itemsOnShelf.Length; i++)
        {
            if (itemsOnShelf[i].activeSelf)
            {
                activeIndices.Add(i);
            }
        }

        for (int i = 0; i < activeIndices.Count; i++)
        {
            int randomIndex = Random.Range(i, activeIndices.Count);
            (activeIndices[i], activeIndices[randomIndex]) = (activeIndices[randomIndex], activeIndices[i]);
        }

        int countToRemove = Mathf.Min(removeCount, activeIndices.Count);
        for (int i = 0; i < countToRemove; i++)
        {
            int indexToDisable = activeIndices[i];
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

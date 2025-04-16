using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public GameObject TargetItem;
    public NavMeshAgent Customer;

    private ItemRandomizer ItemRandomizer;

    private void Awake()
    {
        {
            ItemRandomizer = GetComponent<ItemRandomizer>();
        }
    }
    public void FindPath()
    {
            string Item = ItemRandomizer.Item;
            TargetItem = GameObject.Find(Item);
    }

    public void Update()
    {
        if (TargetItem != null)
        {
        Customer.destination = TargetItem.transform.position;
        }
        else
        {
        Customer.destination = GameObject.Find("Spawn").transform.position;
        FindPath();
        }
    }
}

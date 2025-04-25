using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Customer;
    public Transform SpawnPad;
    public Transform folderParent;
    public float SpawnRate;

    ValueHolder Holder;

    private float SpawnTimer;

    private void Awake()
    {
        Holder = FindAnyObjectByType<ValueHolder>();
    }

    void Update()
    {
        if (Holder.OncomingCustomers > 0)
        {
            SpawnTimer += Time.deltaTime;

            if (SpawnTimer >= SpawnRate)
            {
                Instantiate(Customer, SpawnPad.position, SpawnPad.rotation, folderParent);
                SpawnTimer = 0f;
                Holder.DecrementInt();
            }
        }
    }
}
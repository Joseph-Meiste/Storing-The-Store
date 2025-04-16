using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Customer;
    public Transform SpawnPad;
    public float SpawnRate;
    
    private float SpawnTimer;
    
    void Update()
    {
    SpawnTimer+= Time.deltaTime;

    if (SpawnTimer >= SpawnRate)
    {
        Instantiate(Customer, SpawnPad.position, SpawnPad.rotation);
        SpawnTimer = 0f;
    }    
    }
}

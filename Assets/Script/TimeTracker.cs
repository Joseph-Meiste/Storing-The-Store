using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public bool isDay = true;
    public int CompletedCustomers;
    public int OncomingCustomers;
    public int NumberOfTrash;

    public GameObject Garbage;
    public Transform TrashParent;

    private void IncrementInt()
    {
        CompletedCustomers++;
    }

    private void DecrementInt()
    {
        OncomingCustomers--;
    }

    private void SpawnTrash()
    {
        Instantiate(Garbage, PathFinding.Customer.position, TrashParent);
    }

    private void BreakLight()
    {
        //vn 0.791478 -0.068726 0.607322 
    }
}


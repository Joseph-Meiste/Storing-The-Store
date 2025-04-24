using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    public bool isDay = true;
    public int CompletedCustomers;
    public int OncomingCustomers;
    public int NumberOfTrash;

    public void IncrementInt()
    {
        CompletedCustomers++;
    }

    public void DecrementInt()
    {
        OncomingCustomers--;
    }

    public void AddTrashCounter()
    {
        NumberOfTrash++;
    }

    public void BreakLight()
    {
        //vn 0.791478 -0.068726 0.607322 
    }
}
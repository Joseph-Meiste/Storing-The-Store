using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    public bool isDay = true;
    public int DayNumber;
    public int OncomingCustomers;
    public int CompletedCustomers;
    public int requirement;
    public int NumberOfTrash;
    public int NumberOfAngryCustomers;

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

    public void AddAngryCustomer()
    {
        NumberOfAngryCustomers++;
    }

    public void BreakLight()
    {
        //vn 0.791478 -0.068726 0.607322 
    }

    public void CompletedDay()
    {
        DayNumber++;
    }
}
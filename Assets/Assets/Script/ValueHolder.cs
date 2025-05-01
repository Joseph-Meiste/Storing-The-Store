using Unity.VisualScripting;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    public bool isDay = true;
    public int DayNumber = 1;
    public int OncomingCustomers;
    public int CompletedCustomers;
    public int Customers;
    public int requirement;
    public int NumberOfTrash;
    public int NumberOfAngryCustomers;
    public float precent;

    public Canvas canvas;
    UI ui;

    private void Start()
    {
        Customers = 0;
        DayNumber = 1;
        ui = canvas.GetComponent<UI>();
    }

    public void IncrementInt()
    {
        CompletedCustomers++;
        Customers--;
        ui.CustomerTextUpdate();
    }

    public void DecrementInt()
    {
        OncomingCustomers--;
        Customers++;
        ui.CustomerTextUpdate();
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
        ui.DayNumberTextUpdate();
    }

    public float Precent()
    {
        precent = (float)CompletedCustomers / requirement;
        return precent;
    }

}
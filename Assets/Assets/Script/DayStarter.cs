using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private ValueHolder valueHolder;

    void Awake()
    {
        valueHolder = GameObject.Find("Map").GetComponent<ValueHolder>();
        DayOne();
    }

    void Update()
    {
    if (valueHolder.isDay)
    {
        CheckIfDayIsComplete();
    }
    else
    {

    }
    }

    public void DayOne()
    {
        valueHolder.OncomingCustomers = 0;
        valueHolder.isDay = true;
        valueHolder.requirement =0 ;
    }

    public void CheckIfDayIsComplete()
    {
        if (valueHolder.CompletedCustomers == valueHolder.requirement)
        {
            valueHolder.CompletedDay();
            valueHolder.isDay = false;
        }
    }
}

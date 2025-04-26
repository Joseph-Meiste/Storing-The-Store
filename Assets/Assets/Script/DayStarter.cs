using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private ValueHolder valueHolder;
    public GameObject Security;
    public GameObject Player;

    void Awake()
    {
        valueHolder = GameObject.Find("Map").GetComponent<ValueHolder>();
        DayOne();
    }

    void Update()
    {
    if (valueHolder.isDay)
    {
        if (!Security.gameObject.activeSelf)
        {
            Player.SetActive(false);
            Security.gameObject.SetActive(true);
        }
        CheckIfDayIsComplete();
    }
    else
    {
        if (!Player.activeSelf)
        {
            Security.gameObject.SetActive(false);
            Player.SetActive(true);
        }
    }
    }

    public void DayOne()
    {
        valueHolder.OncomingCustomers = 15;
        valueHolder.isDay = true;
        valueHolder.requirement = 15;
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

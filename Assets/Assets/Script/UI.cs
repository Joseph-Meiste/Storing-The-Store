using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text customerCount;
    public Text customerCountDark;
    public Text dayCount;
    public Text dayCountDark;
    public Text Time;

    public GameObject Map;
    public GameObject Day;
    public GameObject Night;

    public float Timer;

    ValueHolder holder;
    DayCounter days;

    private void Start()
    {
        days = Map.GetComponent<DayCounter>();
        holder = Map.GetComponent<ValueHolder>();
        CustomerTextUpdate();
    }

    public void CustomerTextUpdate()
    {
        customerCount.text = "Customers: " + holder.Customers.ToString();
        customerCountDark.text = "Customers: " + holder.Customers.ToString();
    }

    public void DayNumberTextUpdate()
    {
        dayCount.text = "Day: " + holder.DayNumber.ToString();
        dayCountDark.text = "Day: " + holder.DayNumber.ToString();
    }

    public void CameraUI()
    {
        Night.SetActive(false);
        Day.SetActive(true);
    }

    public void PlayerUI()
    {
        Day.SetActive(false);
        Night.SetActive(true);
    }


    public float CountDown()
    {
        Timer -= UnityEngine.Time.deltaTime;
        
        float value = Timer;

        if (Timer < 0)
        {
            days.DayOne();
            Timer = 30;
        }
        return value;
    }

    private void Update()
    {
        if (!holder.isDay)
        {
            float value = CountDown();
        value = Mathf.Max(0, Mathf.Round(Timer * 10f) / 10f);
        Time.text = value.ToString() + "s";
        }
    }
}

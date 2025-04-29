using System.Linq;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private string Aisles;
    private string Freezers;
    private string Tables;
    private string Bins;

    private string[] AislesArray;
    private string[] FreezersArray;
    private string[] TablesArray;
    private string[] BinsArray;

    private ValueHolder valueHolder;

    void Awake()
    {
        valueHolder = GameObject.Find("Map").GetComponent<ValueHolder>();
    }

    private void Start()
    {
        Aisles = "Engine, Cargo, Caboose, Pans, Containers, Glass-Cups, Napkins, Paper-Plates, Plastic-Utensils, Popcorn, Chips, Cookies, Bars, Packets, Suckers, Candles, Plants, Picture-Frames, Pencils, Markers, Paper, Bucket, Product, Gloves, Soap, ToothPaste, Toilet-Paper";
        AislesArray = Aisles.Split(',').Select(s => s.Trim()).ToArray();

        Freezers = "Ice-Cream , Pizzas, Waffles, Milk , Juice, Water";
        FreezersArray = Freezers.Split(',').Select(s => s.Trim()).ToArray();

        Tables = "Action-Figures, Mini-Houses, 8-Balls";
        TablesArray = Tables.Split(',').Select(s => s.Trim()).ToArray();

        Bins = "Soccer-Balls, Basket-Balls";
        BinsArray = Bins.Split(',').Select(s => s.Trim()).ToArray();

        DayOne();
    }

    void Update()
    {
    if (valueHolder.isDay)
    {
        CheckIfDayIsComplete();
    }
    }

    public void DayOne()
    {
        Reset();
        valueHolder.OncomingCustomers = 5;
        valueHolder.isDay = true;
        valueHolder.requirement = 5;
    }

    public void CheckIfDayIsComplete()
    {
        if (valueHolder.CompletedCustomers == valueHolder.requirement)
        {
            valueHolder.CompletedDay();
            valueHolder.isDay = false;
        }
    }

    public void Reset()
    {
        foreach (var item in AislesArray) 
        {
            CheckOverLoad checkOverLoad = GameObject.Find(item).GetComponent<CheckOverLoad>();
            checkOverLoad.UsesLeft = 5;
        }
        foreach (var item in FreezersArray)
        {
            CheckOverLoad checkOverLoad = GameObject.Find(item).GetComponent<CheckOverLoad>();
            checkOverLoad.UsesLeft = 4;
        }
        foreach (var item in TablesArray)
        {
            CheckOverLoad checkOverLoad = GameObject.Find(item).GetComponent<CheckOverLoad>();
            checkOverLoad.UsesLeft = 3;
        }
        foreach (var item in BinsArray)
        {
            CheckOverLoad checkOverLoad = GameObject.Find(item).GetComponent<CheckOverLoad>();
            checkOverLoad.UsesLeft = 3;
        }
    }
}

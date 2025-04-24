using System;
using UnityEngine;

public class ItemRandomizer : MonoBehaviour
{
    public string Type;
    public string Shelf;
    public string Item;

    private int TypeNum;
    private int ShelfNum;
    private int ItemNum;

    private PathFinding PathFinder;
    private CheckOverLoad CheckOverLoad;


    void Awake()
    {
        CheckOverLoad = GetComponent<CheckOverLoad>();
        PathFinder = GetComponent<PathFinding>();
    }

    private void Start()
    {
        FindItem();
    }

    private void FindItem()
    {
        GenerateItem();
        CheckOverLoad targetShelf = GameObject.Find(Item).GetComponent<CheckOverLoad>();
        bool worked = targetShelf.Verify();

        if (!worked)
        {
            FindItem();
        }

        PathFinder.FindPath();
    }

    private void GenerateItem()
    {
        TypeNum = UnityEngine.Random.Range(1, 14);

        if (TypeNum >= 1 && TypeNum <= 2)
        {
            Type = "Freezers";
            ShelfNum = 0;
            ItemNum = UnityEngine.Random.Range(1, 7);
            Item = new string[] { "Ice-Cream", "Pizzas", "Waffles", "Milk", "Juice", "Water" }[ItemNum - 1];
        }
        else if (TypeNum >= 3 && TypeNum <= 4)
        {
            Type = "Islands";
            ShelfNum = UnityEngine.Random.Range(1, 3);

            if (ShelfNum == 1)
            {
                Shelf = "Ball Bins + Table";
                Item = new string[] { "Basket-Balls", "8-Balls", "Soccer-Balls" }[UnityEngine.Random.Range(0, 3)];
            }
            else
            {
                Shelf = "Table";
                Item = new string[] { "Action-Figures", "Mini-Houses" }[UnityEngine.Random.Range(0, 2)];
            }
        }
        else
        {
            Type = "Aisles";
            ShelfNum = UnityEngine.Random.Range(1, 10);

            switch (ShelfNum)
            {
                case 1:
                    Shelf = "Kitchen";
                    Item = new string[] { "Pans", "Containers", "Glass-Cups" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 2:
                    Shelf = "Paper-Stuff";
                    Item = new string[] { "Paper-Plates", "Napkins", "Plastic-Utensils" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 3:
                    Shelf = "Snacks";
                    Item = new string[] { "Popcorn", "Chips", "Cookies" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 4:
                    Shelf = "Candy";
                    Item = new string[] { "Bars", "Packets", "Suckers" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 5:
                    Shelf = "Home-Deco";
                    Item = new string[] { "Candles", "Plants", "Picture-Frames" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 6:
                    Shelf = "Arts-n-Crafts";
                    Item = new string[] { "Pencils", "Markers", "Paper" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 7:
                    Shelf = "Cleaning-Supplies";
                    Item = new string[] { "Bucket", "Gloves", "Product" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 8:
                    Shelf = "Bathroom-Essentails";
                    Item = new string[] { "Soap", "ToothPaste", "Toilet-Paper" }[UnityEngine.Random.Range(0, 3)];
                    break;
                case 9:
                    Shelf = "Train-Models";
                    Item = new string[] { "Engine", "Cargo", "Caboose" }[UnityEngine.Random.Range(0, 3)];
                    break;
            }
        }
    }
}
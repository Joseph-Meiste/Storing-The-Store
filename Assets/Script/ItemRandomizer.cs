using System;
using System.Collections;
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


    //Ice-Cream Pizzas Waffles Milk Juice Water

    //Basket-Balls 8-Balls Soccer-Balls Action-Figures Mini-Houses

    //Kitchen (Pans, Containers, Glass-Cups) Disposable-Items (Paper-Plates, Napkins, Plastic-Utensils) Snacks (Popcorn, Chips, Cookies) Candy (Bars, Packets, Suckers)
    //Home-Deco (Candles, Plants, Picture-Frames) Arts-n-Crafts (Pencils, Markers, Paper) Cleaning-Supplies (Bucket, Bottles, Gloves) Bathroom-Essentials (Soap, ToothPaste, Toilet-Paper) Train-Models (Engine, Cargo, Caboose)

    void Start()
    {
        PathFinder = GetComponent<PathFinding>();
        TypeNum = UnityEngine.Random.Range(1, 14);
        
        //Freezers
        if (TypeNum >= 1 && TypeNum <= 2)
        {
            Type = ("Freezers");
            ShelfNum = 0;
            ItemNum = UnityEngine.Random.Range(1, 8);

            //Items
            switch (ItemNum)
            {
                case 1:
                    Item = ("Ice-Cream");
                    break;
                case 2:
                    Item = ("Pizzas");
                    break;
                case 3:
                    Item = ("Waffles");
                    break;
                case 4:
                    Item = ("Pizza-Rolls");
                    break;
                case 5:
                    Item = ("Milk");
                    break;
                case 6:
                    Item = ("Juice");
                    break;
                case 7:
                    Item = ("Water");
                    break;
            }
        }
        //Islands
        else if(TypeNum >= 3 && TypeNum <= 4)
        {
            Type = ("Islands");
            ShelfNum = UnityEngine.Random.Range(1, 3);
            
            //Ball + Table
            if (ShelfNum == 1)
            {
                Shelf = ("Ball Bins + Table");
                ItemNum = UnityEngine.Random.Range(1, 4);

                switch (ItemNum)
                {
                    case 1:
                        Item = ("Basket-Balls");
                        break;
                    case 2:
                        Item = ("8-Ball");
                        break;
                    case 3:
                        Item = ("Soccer-Balls");
                        break;
                }
            }
            //Tables
            else
            {
                Shelf = ("Table");
                ItemNum = UnityEngine.Random.Range(1, 3);

                switch (ItemNum)
                {
                    case 1:
                        Item = ("Action-Figures");
                        break;
                    case 2:
                        Item = ("Mini-Houses");
                        break;
                }
            }
        }
        //Aisles
        else
        {
            Type = ("Aisles");
            ShelfNum = UnityEngine.Random.Range(1, 10);

            switch (ShelfNum)
            {
                //Kitchen
                case 1:
                    Shelf = ("Kitchen");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Pans");
                            break;
                        case 2:
                            Item = ("Containers");
                            break;
                        case 3:
                            Item = ("Glass-Cups");
                            break;
                    }
                    break;
                //Disposable Items
                case 2:
                    Shelf = ("Paper-Stuff");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Paper-Plates");
                            break;
                        case 2:
                            Item = ("Napkins");
                            break;
                        case 3:
                            Item = ("Plastic-Utensils");
                            break;
                    }
                    break;
                //Snacks
                case 3:
                    Shelf = ("Snacks");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Popcorn");
                            break;
                        case 2:
                            Item = ("Chips");
                            break;
                        case 3:
                            Item = ("Cookies");
                            break;
                    }
                    break;
                //Candy
                case 4:
                    Shelf = ("Candy");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Bars");
                            break;
                        case 2:
                            Item = ("Packets");
                            break;
                        case 3:
                            Item = ("Suckers");
                            break;
                    }
                    break;
                //Home-Deco
                case 5:
                    Shelf = ("Home-Deco");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Candles");
                            break;
                        case 2:
                            Item = ("Plants");
                            break;
                        case 3:
                            Item = ("Picture-Frames");
                            break;
                    }
                    break;
                //Arts-n-Crafts
                case 6:
                    Shelf = ("Arts-n-Crafts");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Pencils");
                            break;
                        case 2:
                            Item = ("Markers");
                            break;
                        case 3:
                            Item = ("Paper");
                            break;
                    }
                    break;
                //Cleaning-Supplies
                case 7:
                    Shelf = ("Cleaning-Supplies");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Bucket");
                            break;
                        case 2:
                            Item = ("Gloves");
                            break;
                        case 3:
                            Item = ("Product");
                            break;
                    }
                    break;
                //Bathroom-Essentials
                case 8:
                    Shelf = ("Bathroom-Essentails");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Soap");
                            break;
                        case 2:
                            Item = ("ToothPaste");
                            break;
                        case 3:
                            Item = ("Toilet-Paper");
                            break;
                    }
                    break;
                //Train-Models
                case 9:
                    Shelf = ("Train-Models");
                    ItemNum = UnityEngine.Random.Range(1, 4);
                    switch (ItemNum)
                    {
                        case 1:
                            Item = ("Engine");
                            break;
                        case 2:
                            Item = ("Cargo");
                            break;
                        case 3:
                            Item = ("Caboose");
                            break;
                    }
                    break;
            }
        }

        PathFinder.FindPath();
    }
}

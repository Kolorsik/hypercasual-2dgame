using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopItems
{
    public int id;
    public int price;
    public string name;

    public ShopItems(int _id, int _price, string _name)
    {
        id = _id;
        price = _price;
        name = _name;
    }

    public ShopItems() { }

    public List<ShopItems> GetAllItems()
    {
        return new List<ShopItems>()
        {
            new ShopItems(0, 0, "Square"),
            new ShopItems(1, 1, "Circle"),
            new ShopItems(2, 1, "Polygon"),
            new ShopItems(3, 1, "Star")
        };
    }
}

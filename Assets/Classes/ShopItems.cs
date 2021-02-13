using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        ShopItems square = new ShopItems(0, 0, "Square");
        ShopItems circle = new ShopItems(1, 1, "Circle");
        ShopItems polygon = new ShopItems(2, 1, "Polygon");
        ShopItems star = new ShopItems(3, 1, "Star");
        return new List<ShopItems>() { square, circle, polygon, star };
    }
}

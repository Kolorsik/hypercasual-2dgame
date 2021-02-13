using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject PriceText;
    public GameObject BuyButton;

    private List<ShopItems> shopItems;

    // Start is called before the first frame update
    void Start()
    {
        ShopItems si = new ShopItems();
        shopItems = si.GetAllItems();
    }

    public void BuySquare()
    {
        ShopItems square = shopItems.Where(x => x.name == "Square").SingleOrDefault();
        SaveSystem.ChangeFigure(square);
    }

    public void BuyCircle()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems circle = shopItems.Where(x => x.name == "Circle").SingleOrDefault();
        if (pd.AvailableScore >= circle.price)
        {
            SaveSystem.ChangeAvaliableScore(circle.price);
            SaveSystem.ChangeFigure(circle);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

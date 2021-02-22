using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text PriceText;
    public Text ButtonText;
    public RawImage TestColor;

    private List<ShopItems> shopItems;
    private ShopItems SelectedFigure;
    private float R = 0f, G = 0f, B = 0f;

    public void OnValueChangedR(float value)
    {
        R = value;
        TestColor.color = new Color(R / 255f, G / 255f, B / 255f);
    }

    public void OnValueChangedG(float value)
    {
        G = value;
        TestColor.color = new Color(R / 255f, G / 255f, B / 255f);
    }

    public void OnValueChangedB(float value)
    {
        B = value;
        TestColor.color = new Color(R / 255f, G / 255f, B / 255f);
    }

    public void ChangePlayerColor()
    {
        SaveSystem.ChangeColor(R, G, B);
    }

    // Start is called before the first frame update
    void Start()
    {
        ShopItems si = new ShopItems();
        PlayerData pd = SaveSystem.LoadPlayer();
        shopItems = si.GetAllItems();
        SelectedFigure = pd.SelectedFigure;
    }

    public void SelectPolygon()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems polygon = shopItems.Where(x => x.name == "Polygon").SingleOrDefault();
        ShopItems playerFigure = pd.BoughtFigures.Where(x => x.name == polygon.name).SingleOrDefault();
        if (playerFigure != null)
        {
            PriceText.text = "Фигура 'Многоугольник' куплена";
            ButtonText.text = "Выбрать фигуру";
        }
        else
        {
            PriceText.text = "Цена фигуры: " + polygon.price.ToString();
            ButtonText.text = "Купить фигуру";
        }
        SelectedFigure = polygon;
    }

    public void SelectStar()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems star = shopItems.Where(x => x.name == "Star").SingleOrDefault();
        ShopItems playerFigure = pd.BoughtFigures.Where(x => x.name == star.name).SingleOrDefault();
        if (playerFigure != null)
        {
            PriceText.text = "Фигура 'Звезда' куплена";
            ButtonText.text = "Выбрать фигуру";
        }
        else
        {
            PriceText.text = "Цена фигуры: " + star.price.ToString();
            ButtonText.text = "Купить фигуру";
        }
        SelectedFigure = star;
    }

    public void SelectSquare()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems square = shopItems.Where(x => x.name == "Square").SingleOrDefault();
        ShopItems playerFigure = pd.BoughtFigures.Where(x => x.name == square.name).SingleOrDefault();
        if (playerFigure != null)
        {
            PriceText.text = "Фигура 'Квадрат' куплена";
            ButtonText.text = "Выбрать фигуру";
        }
        else
        {
            PriceText.text = "Цена фигуры: " + square.price.ToString();
            ButtonText.text = "Купить фигуру";
        }
        SelectedFigure = square;
    }

    public void SelectCircle()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems circle = shopItems.Where(x => x.name == "Circle").SingleOrDefault();
        ShopItems playerFigure = pd.BoughtFigures.Where(x => x.name == circle.name).SingleOrDefault();
        if (playerFigure != null)
        {
            PriceText.text = "Фигура 'Круг' куплена";
            ButtonText.text = "Выбрать фигуру";
        }
        else
        {
            PriceText.text = "Цена фигуры: " + circle.price.ToString();
            ButtonText.text = "Купить фигуру";
        }
        SelectedFigure = circle;
    }

    public void BuyFigure()
    {
        PlayerData pd = SaveSystem.LoadPlayer();
        ShopItems playerFigure = pd.BoughtFigures.Where(x => x.name == SelectedFigure.name).SingleOrDefault();
        if (playerFigure != null)
        {
            SaveSystem.ChangeFigure(SelectedFigure);
        }
        else
        {
            if (SelectedFigure.price <= pd.AvailableScore)
            {
                SaveSystem.ChangeAvaliableScore(SelectedFigure.price);
                SaveSystem.ChangeFigure(SelectedFigure);
                SaveSystem.ChangeBoughtFigures(SelectedFigure);
            }
            else
            {
                PriceText.text = "Не хватает очков!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

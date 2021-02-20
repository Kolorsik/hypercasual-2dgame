using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int AvailableScore;
    public int TotalScore;
    public List<ShopItems> BoughtFigures;
    public ShopItems SelectedFigure;
    public Color SelectedColor;
    public PlayerData() { }
}

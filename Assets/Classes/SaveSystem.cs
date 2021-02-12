using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public static class SaveSystem
{
    public static void ResetPlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath + "/PlayerData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData tempData = new PlayerData();
        tempData.AvailableScore = 0;
        tempData.TotalScore = 0;

        bf.Serialize(stream, tempData);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/PlayerData.dat";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData();
            data.TotalScore = 0;
            data.AvailableScore = 0;

            bf.Serialize(stream, data);
            stream.Close();

            return null;
        }
    }

    public static void SaveScore(int score)
    {
        PlayerData tempData = LoadPlayer();
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath + "/PlayerData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        tempData.AvailableScore += score;
        tempData.TotalScore += score;

        bf.Serialize(stream, tempData);
        stream.Close();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaverBase : MonoBehaviour
{
    public GameObject[] stars;
    public int _numStars;
    public bool openLevel;

    [Multiline(20)]
    public string data;

    public void CollectInfo()
    {
        _numStars = 3;
        openLevel = true;
    }

    public void SetInfo()
    {
        if (openLevel)
        {
            stars[_numStars].SetActive(true);
        }
    }

    public void Save()
    {
        CollectInfo();
        data = JsonUtility.ToJson(this, true);
       var json = JsonUtility.ToJson(data);
        using (var writer = new StreamWriter(data))
        {
            writer.WriteLine(json);
        }

        File.WriteAllText("D:/save.json", data);
    }

    public void Load()
    {
        data = File.ReadAllText("D:/save.json");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textAsset;

    [Serializable]
    public class Player
    {
        public int levelID;
        public string levelName;
        public int starsNum;
    }

    [Serializable]
    public class PlayerList
    {
        public Player[] levelsList;
    }

    public PlayerList myLevelList = new PlayerList();

    private void Start()
    {
        myLevelList = JsonUtility.FromJson<PlayerList>(textAsset.text);
    }
}

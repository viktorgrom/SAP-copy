using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.IO;
using static CGameData;
using static GameHandler;
using static JSONReader;

public class GameHandler : MonoBehaviour
{
    public LevelDataLists myLevelDataList2;
    
    // public List <LevelData> myLevelDataListt = new List<LevelData>();
   // public LevelData[] myLevelDataList = new LevelData[5];

    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Resources/LevelData.json");
        myLevelDataList2 = JsonUtility.FromJson<LevelDataLists>(json);

        myLevelDataList2.levelDataList[0].levelId = 10;
        myLevelDataList2.levelDataList[1].levelId = 2;

        Debug.Log(myLevelDataList2.levelDataList[0].levelId);

        //  myLevelDataList[1].numStars = 2;
        // Debug.Log(myLevelDataListt[0].levelId);

        //  myLevelDataList = new List <LevelData>(new LevelData[20]);

        // myLevelDataList[1].numStars = 2;


        /* for (int i = 0; i < myLevelDataList.levelDataList.Count; i++)
         {
             if(i == 20)
                 return;

             myLevelDataList.levelDataList[i].levelId = i;
             myLevelDataList.levelDataList[i].numStars = 0;
             myLevelDataList.levelDataList[i].active = 0;
             myLevelDataList.levelDataList[0].active = 1;
         }*/

        // Debug.Log(myLevelDataList[1].numStars);


        /* LevelData playerData = new LevelData();
          playerData.position = new Vector3(5, 0);
          playerData.health = 80;*/

         string json2 = JsonUtility.ToJson(myLevelDataList2, true);
        //  Debug.Log(json);

         File.WriteAllText(Application.dataPath + "/Resources/LevelData.json", json2);

        /* string json = File.ReadAllText(Application.dataPath + "/Resources/LevelData.json");

        var tpmLevelData = JsonUtility.FromJson<CLevelSelectList>(json);*/

    }





    [Serializable]
    public class LevelDatas
    {
        public int levelId;
        public int numStars;
        public int active;
    }

    [Serializable]
    public class LevelDataLists
    {
        public LevelDatas[] levelDataList;
    }
}

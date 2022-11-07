using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;


public class CGameData
{
    private readonly string levelSavePlace = Application.dataPath + "/Resources/LevelData.json";
    private LevelDataList mLevelConfigsList;
    public LevelDataList ConfigsList
    {
        get { return mLevelConfigsList; }
        set { mLevelConfigsList = value; }
    }
    public int mActiveLevelId;
    public int maxActiveLevelId;
    /* public List<CLevelConfig> ConfigsList
     {
         get { return mLevelConfigsList; }
         set { mLevelConfigsList = value; }
     }*/

    private void Start()
    {
        // ParseGameConfigs();
        ParseGameData();
    }

    public void ParseGameData()
    {
        string json = File.ReadAllText(levelSavePlace);
        mLevelConfigsList = JsonUtility.FromJson<LevelDataList>(json);

        for (int i = 0; i < mLevelConfigsList.levelDataList.Length; i++)
        {
            if (mLevelConfigsList.levelDataList[i].active == 1 && mLevelConfigsList.levelDataList[i].numStars > 0)
            {
                maxActiveLevelId = mLevelConfigsList.levelDataList[i].levelId;                
            }
        }

        Debug.Log("Parse");
       // Debug.Log(mLevelConfigsList.levelDataList[0].numStars);

    }

    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(mLevelConfigsList, true);

        File.WriteAllText(levelSavePlace, json);
    }
    public void SetActiveLevel(int levelID)
    {
        mActiveLevelId = levelID;
    }
    public void levelFinished(int stars)
    {
        Debug.Log("active level " + mActiveLevelId);

        for (int i = 0; i < mLevelConfigsList.levelDataList.Length; i++)
        {
            if (mLevelConfigsList.levelDataList[i].levelId == mActiveLevelId)
            {
                mLevelConfigsList.levelDataList[i].numStars = stars;

            }

            //next level active
            if(mLevelConfigsList.levelDataList[i].levelId == mActiveLevelId + 1)
            {
                mLevelConfigsList.levelDataList[i].active = 1;
                Debug.Log("active new level " + mActiveLevelId);
            }
        }
        SaveGameData();

       // SceneManager.LoadScene("Levels");
    }

    [Serializable]
    public class LevelData
    {
        public int levelId;
        public int numStars;
        public int active;
    }

    [Serializable]
    public class LevelDataList
    {
        public LevelData[] levelDataList;
    }
}


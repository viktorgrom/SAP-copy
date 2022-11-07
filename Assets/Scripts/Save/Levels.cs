using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using static CGameData;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public CGameData mGameData = null;
    private LevelDataList levelDataList;

    public GameObject[] levelSlot;
    int maxActiveLevel;
    private void Start()
    {
        mGameData = new CGameData();
        mGameData.ParseGameData();
        levelDataList = mGameData.ConfigsList;

        Debug.Log("initialization");
        LoadLevelsData();
    }

    private void LevelFinished()
    {        
      //  mGameData.levelFinished(5);
        
        //save
     //   mGameData.SaveGameConfigInJson();
    }
    public void LoadLevelsData()
    {       
        int uLevelID;
        int uNumStars;
        int uActive;

        for (int i = 0; i < levelDataList.levelDataList.Length; i++)
        {
            uLevelID = levelDataList.levelDataList[i].levelId;
            uNumStars = levelDataList.levelDataList[i].numStars;
            uActive = levelDataList.levelDataList[i].active;

            if (uActive > 0)
            {
                maxActiveLevel = levelDataList.levelDataList[i].levelId;
                Debug.Log(uLevelID + " " + uActive);
              //  CGameManager.Instance.mGameData.mActiveLevelId = maxActiveLevel;
                levelSlot[i].transform.GetChild(0).gameObject.SetActive(true);
                levelSlot[i].transform.GetChild(1).gameObject.SetActive(false);
                levelSlot[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = uLevelID.ToString();
                levelSlot[i].transform.GetChild(0).GetChild(1).GetChild(uNumStars).gameObject.SetActive(true);
            }
        }       
    }

    public void StartScene(int sceneNum)
    {
        if (CheckActiveLevel(sceneNum))
        {
            CGameManager.Instance.mGameData.SetActiveLevel(sceneNum);
            SceneManager.LoadScene(sceneNum + "lvl"); 
           // Stats.instance.SetScoreLevelNull();
        }            
        else
            Debug.Log("Level is not active");
    }

    private bool CheckActiveLevel(int levelToCheck)
    {
        bool activeToLoad = false;

        for (int i = 0; i < levelDataList.levelDataList.Length; i++)
        {
            
            if (levelDataList.levelDataList[i].levelId == levelToCheck)
                if (levelDataList.levelDataList[i].active > 0)
                    activeToLoad = true;                
        }
        return activeToLoad;
    }
}

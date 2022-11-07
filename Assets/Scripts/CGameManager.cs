using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using ActionSystem;
using UnityEngine.UI;
using static CGameData;

public class CGameManager : MonoBehaviour
{

    // [SerializeField] private AppLovinAdsReward appLovinAdsReward;
    private int _score;
    public int Score { get { return _score; } }
   // public int activeLevel;
    
    public static CGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CGameManager>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("CGameManager");
                    instance = instanceContainer.AddComponent<CGameManager>();
                    Debug.Log("instance");
                }
            }
            return instance;
        }
    }
    private static CGameManager instance;

    public CGameData mGameData = null;
    
  //  public CGUIManager mGUIManager = null;
   // public CAdsManager mAdsManager = null;
    //public CPurchaseManager mPurchaseManager = null;

    private void Start()
    {
        Initialization();


        // appLovinAdsReward = FindObjectOfType<AppLovinAdsReward>();

       // LoadStarsTest();
        //  CLevelSelectList uLevelConfigsList = mGameData.ConfigsList;
        //string str = mGameData.mLevelConfigsList.ToString();
        // Debug.Log(str);
    }

    public void Initialization()
    {
        mGameData = new CGameData();
        
        //mGUIManager = this.transform.GetComponent<CGUIManager>();

        mGameData.ParseGameData();
        Debug.Log("initialization");
    }
    public void SetLevelID(int sceneID)
    {
        mGameData.SetActiveLevel(sceneID);
    }
    public void SwitchScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void LoadScene(string sceneName)
    {
        if(Stats.instance != null)
        {
            Stats.instance.LevelQuantToAds += 1;
        }
        
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void IsGameFinished(int gotStars)
    {
        
        mGameData.levelFinished(gotStars);
      //  mGUIManager.ShowGameFinishWindow(gotStars);
        //Time.timeScale = 0f;
        //save
       // mGameData.SaveGameData();
    }

   /* public void LoadAvailableScene()
    {
        LevelDataList uLevelConfigsList = mGameData.ConfigsList;

        int uLevelID;
        int uNumStars;
        int uActive;

        for (int i = 0; i < uLevelConfigsList.levelDataList.Length; i++)
        {
            uLevelID = uLevelConfigsList.levelDataList[i].levelId;
            uNumStars = uLevelConfigsList.levelDataList[i].numStars;
            uActive = uLevelConfigsList.levelDataList[i].active;

            if (uActive == 0)
            {
                CGameManager.Instance.SetLevelID(uLevelID);
                CGameManager.Instance.SwitchScene(uNumStars);
                return;
            }

            if (uLevelConfigsList.levelDataList[uLevelConfigsList.levelDataList.Length - 1].active == 1)
            {
                CGameManager.Instance.SetLevelID(uLevelConfigsList.levelDataList[uLevelConfigsList.levelDataList.Length - 1].levelId);
                CGameManager.Instance.SwitchScene(uLevelConfigsList.levelDataList[uLevelConfigsList.levelDataList.Length - 1].levelId);
                return;
            }


        }
    }*/

   /* public void LoadStarsTest()
    {
        LevelDataList uLevelConfigsList = mGameData.ConfigsList;

        int uLevelID;
        int uStarsNum;
        int uLevelCompleted;

        

        for (int i = 0; i < uLevelConfigsList.levelDataList.Length; i++)
        {
            uLevelID = uLevelConfigsList.levelDataList[i].levelId;

            uStarsNum = uLevelConfigsList.levelDataList[i].numStars;
            uLevelCompleted = uLevelConfigsList.levelDataList[i].active;

            if(uLevelConfigsList.levelDataList[i].active > 0)
                activeLevel = i;


        }
    }*/


    public void LoadNextLevel()
    {

       SceneManager.LoadScene(mGameData.mActiveLevelId + "lvl");
        
        
        // appLovinAdsReward.ShowRewardAd();

        Debug.Log("showAd");

       // mGameData.levelFinished(mGameData.mActiveLevelId);
       // mGUIManager.ShowGameFinishWindow();
        //save
       // mGameData.SaveGameData();

        //analytic


    }

}

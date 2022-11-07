
using UnityEngine;
using UnityEngine.SceneManagement;
using static CGameData;


public class Restart : MonoBehaviour
{
    public CGameData mGameData = null;
    private LevelDataList levelDataList;
    private Scene scene;
    [SerializeField] int maxActiveLevel;

    private void Start()
    {
        mGameData = new CGameData();               
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Levels");

        
    }

    public void RestartCurrentScene()
    {
        if (Stats.instance != null)
        {
            Stats.instance.LevelQuantToAds += 1;
        }

        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

    }

    public void LoadNextLevel()
    {
        if (Stats.instance != null)
        {
            Stats.instance.LevelQuantToAds += 1;
        }

        mGameData.ParseGameData();
        levelDataList = mGameData.ConfigsList;

        for (int i = 0; i < levelDataList.levelDataList.Length; i++)
        {
            if (levelDataList.levelDataList[i].active > 0)
                maxActiveLevel = levelDataList.levelDataList[i].levelId;
        }

        Debug.Log(maxActiveLevel);
        CGameManager.Instance.mGameData.SetActiveLevel(maxActiveLevel);
        SceneManager.LoadScene(maxActiveLevel.ToString() + "lvl");
    }



}

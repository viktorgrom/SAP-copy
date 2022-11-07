using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static CGameData;


public class CLevelStartScene : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;

    public void LoadLevelSelectScene()
    {
        SceneManager.LoadSceneAsync("Levels");
    }

    public void LoadOptionWindow()
    {
        Instantiate(optionWindow, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void LoadAvailableScene()
    {
       // CGameManager.Instance.LoadAvailableScene();
    }
    void OnApplicationPause(bool isPaused)
    {
        Debug.Log("unity-script: OnApplicationPause = " + isPaused);
        // IronSource.Agent.onApplicationPause(isPaused);
    }
}


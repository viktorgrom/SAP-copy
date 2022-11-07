using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    // [SerializeField] private AppLovinReward _lovinReward;
    public static Stats instance = null;
   // public event Action _updateLevelScoreUI;

    [Header("Score")]
    [SerializeField] private int _totalScore;
    [SerializeField] private int _levelScore;
    public int Score { get { return _totalScore; } }
    public int levelStar;
    public int ScoreLevel
    {
        get { return _levelScore; }
        set
        {
            _levelScore = value;
            // _updateLevelScoreUI?.Invoke();
            Debug.Log("level score + " + value);
            // _totalScore += value;
        }
    }

    [Header("Ads")]
    private AppLovinInterstitial _appLovinInterstitial;
    [SerializeField] private int _levelQuantToAds;
    public int LevelQuantToAds { get { return _levelQuantToAds; }
        set
        {
            _levelQuantToAds += value;
            if (_levelQuantToAds == 3)
            {
                _levelQuantToAds = 0;
               // _appLovinInterstitial.ShowInterstitial();
                Debug.Log("level quant to ads + " + value);
            }
        }
    }    

    [Header("Money")]
    [SerializeField] private int _money = 0;
    [SerializeField] private int _coin = 0;

   
    [Space(10)]
    [SerializeField] private int _currentSceneIndex;
    public int maxSceneIndex;

    [SerializeField] private bool _adsUpgrate = false;

    [Header("Purchase")]
    [SerializeField] private int _adsOff;


    [Header("Sound")]
    [SerializeField] private bool _sound;
    [SerializeField] private bool _music;

    public int CurrentSceneIndex
    {
        get
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            return _currentSceneIndex;
        }
        private set
        {
            _currentSceneIndex = value;
            PlayerPrefs.SetInt("LastPlayedScene", _currentSceneIndex);
        }
    }

    public int Money
    {
        get
        {
            return _money;
        }
        private set
        {
            _money = value;
        }
    }

    public int Coin
    {
        get
        {
            return _coin;
        }
        private set
        {
            _coin = value;
        }
    }

    public int AdsOffInt
    {
        get
        {
            return _adsOff;
        }

    }

   

    private bool isNeedToInit = true;



    private void Awake()
    {
        Debug.Log("Stats Awake 1");

        if (!instance)
        {
            Debug.Log("Stats Awake 2");
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("Stats Awake 3");

        _totalScore = PlayerPrefs.GetInt("score", 50);
    }

    private void Start()
    {
        _appLovinInterstitial = FindObjectOfType<AppLovinInterstitial>();
        _currentSceneIndex = PlayerPrefs.GetInt("LastPlayedScene", 4);
        Debug.Log("scenaC " + CurrentSceneIndex);


        _money = PlayerPrefs.GetInt("Money", 10000000);
        _coin = PlayerPrefs.GetInt("Coin", 0);

        Debug.Log("Stats Start money = " + _money);
        Debug.Log("Stats Start money = " + _coin);

        _adsOff = PlayerPrefs.GetInt("AdsOff", 0);

    }

    /* private void Update()
     {
         if (isNeedToInit)
         {
             isNeedToInit = false;

             _lovinReward.GetUpgrateFuel += UpgrateFuel;
             _lovinReward.GetUpgrateEngine += UpgrateEngine;
             _lovinReward.GetUpgrateMoney += UpgrateMoney;

         }


     }

     private void OnDisable()
     {
         _lovinReward.GetUpgrateFuel -= UpgrateFuel;
         _lovinReward.GetUpgrateEngine -= UpgrateEngine;
         _lovinReward.GetUpgrateMoney -= UpgrateMoney;
     }*/

    public void LevelQuantToAdsPlus(int plus)
    {
        _levelQuantToAds += plus;
    }

    public void ScorePlus(int plus)
    {
        _totalScore += plus;
    }

    public void MoneyMinus(int minusMoney)
    {
        Money -= minusMoney;
        // MoneyChanged.Invoke(_money);
        PlayerPrefs.SetInt("Money", _money);
        PlayerPrefs.Save();
    }

    public void CoinPlus(int coin)
    {
        Coin += coin;
      //  CoinChanged.Invoke(Coin);
        PlayerPrefs.SetInt("Coin", Coin);
        // PlayerPrefs.Save();
        //  Debug.Log("GotCoins " + Coin);
    }

    public void CoinMinus(int minusCoin)
    {
        Money -= minusCoin;
        // MoneyChanged.Invoke(_money);
        PlayerPrefs.SetInt("Coin", _coin);
        PlayerPrefs.Save();
    }


    public void NextLevel()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(CurrentSceneIndex + "Next Level");

        if (CurrentSceneIndex < maxSceneIndex)
            CurrentSceneIndex++;
        else
            CurrentSceneIndex = maxSceneIndex;

    }  

    public void UpgrateAfretAds()
    {
        _adsUpgrate = true;

    }

    public void UpgrateAfretAdsOff()
    {
        _adsUpgrate = false;

    }


    public void AdsOffInStats()
    {
        _adsOff = 1;


    }

    //New
    public void CalculateTotalScore()
    {
        _totalScore += _levelScore;
        PlayerPrefs.SetInt("score", _totalScore);
        PlayerPrefs.Save();
        _levelScore = 0;
        Debug.Log("save");
    }

}


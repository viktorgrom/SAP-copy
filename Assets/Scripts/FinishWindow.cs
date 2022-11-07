using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishWindow : MonoBehaviour
{
    private FindTargets findTargets;
    [SerializeField] private Text _scoreTxt;    
    [SerializeField] private GameObject[] _stars;       
    [SerializeField] private int _scoreLevelMax;
    [SerializeField] private float _scoreLevelMaxFloat;
    [SerializeField] private float _scoreLevelCurrent;
    private int stars;

  //  public float _earnMoney;
  //  private float _tempEarnMoney = 0;
    private float _currentTimeScore;
  //  private float _timeEarnCoins;
  //  private float _floatEarnedMoney;
    [SerializeField] private float _duration = 2f;

    void Start()
    {
        findTargets = FindObjectOfType<FindTargets>();
        _scoreLevelMax = findTargets.currentLevelScore;
        stars = Stats.instance.levelStar;
        Stats.instance.ScoreLevel = _scoreLevelMax;
        Debug.Log("score Level" + _scoreLevelMax);
        _scoreLevelMaxFloat = _scoreLevelMax;

    }

    private void Update()
    {
       /* if (_scoreLevelCurrent < _scoreLevelMax)
        {
            _scoreLevelCurrent += 10;
            _scoreTxt.text = _scoreLevelCurrent.ToString();
        }
        else
        {
            _stars[stars].SetActive(true);
        }*/

        if (_scoreLevelCurrent < _scoreLevelMaxFloat)
        {
            _currentTimeScore += Time.deltaTime / _duration;
            _scoreLevelCurrent = Mathf.Lerp(0f, _scoreLevelMaxFloat, _currentTimeScore);
            _scoreLevelMax = (int)_scoreLevelCurrent;
            _scoreTxt.text = _scoreLevelMax.ToString();
        }
        else
        {
            _stars[stars].SetActive(true);
        }
    }

   
}

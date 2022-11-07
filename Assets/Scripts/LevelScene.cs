using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LevelScene : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelList;
    [SerializeField] private Image[] _pointsArrey;
    [SerializeField] private Sprite _onCircle;
    [SerializeField] private Sprite _offCircle;
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _activeLavelTxt;

    private int _activePage;
    
    void Start()
    {
        _activePage = 0;
        _levelList[_activePage].transform.SetAsLastSibling();
        _scoreTxt.text = Stats.instance.Score.ToString();

        _activeLavelTxt.text = "Win  " + CGameManager.Instance.mGameData.maxActiveLevelId.ToString() + "/" + CGameManager.Instance.mGameData.ConfigsList.levelDataList.Length.ToString();

        ChangeActivePoint();
    }

    private void OnDestroy()
    {
        
    }

    public void NextPage()
    {
        if(_activePage <= _levelList.Length)
        {
            _activePage++;
            _levelList[_activePage].transform.SetAsLastSibling();
        }

        ChangeActivePoint();

    }

    public void PreviusPage()
    {
        if (_activePage >= 1)
        {
            _activePage--;
            _levelList[_activePage].transform.SetAsLastSibling();
        }

        ChangeActivePoint();

    }

    private void ChangeActivePoint()
    {
        foreach (Image point in _pointsArrey)
        {
            point.sprite = _offCircle;
        }
        _pointsArrey[_activePage].sprite = _onCircle;
    }

    

}

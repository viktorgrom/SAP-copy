using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private CannonFire _cannonFire;
    private FindTargets _findTargets;
    private BulletChanger _bulletChanger;
    [SerializeField] private GameObject _winSlot;
    private int _shootCount;
    [SerializeField] private int _shootCountWinCondition;
    private int _score;
    private int _maxScore;
    private int _gotScore;
    private int _starsWin;


    private void Start()
    {
        _starsWin = Mathf.Max(0, 3);
        _starsWin = 0;
        _cannonFire = FindObjectOfType<CannonFire>();
        _findTargets = FindObjectOfType<FindTargets>();
        _bulletChanger = FindObjectOfType<BulletChanger>();
        _cannonFire._fireEventEnd += ShootCounter;
        _findTargets.winEvent += FinishStarsCounter;
        _findTargets.gotStarEvent += GotStar;
        _bulletChanger.noMoreBulletsEvent += WinSlotOn;
    }

    private void OnDisable()
    {
        _cannonFire._fireEventEnd -= ShootCounter;
        _findTargets.winEvent -= FinishStarsCounter;
        _findTargets.gotStarEvent -= GotStar;
        _bulletChanger.noMoreBulletsEvent -= WinSlotOn;
    }

    private void GotStar()
    {
        _starsWin++;
    }

    public void GetMaxLevelScore(int score)
    {
        _maxScore = score;
    }

    public void ShootCounter()
    {
        _shootCount++;
    }

    private void FinishStarsCounter()
    {
       // _gotScore = Stats.instance.ScoreLevel;
        Stats.instance.CalculateTotalScore();
        Stats.instance.levelStar = _starsWin;
        CGameManager.Instance.IsGameFinished(_starsWin);


        /* if (_shootCount == _shootCountWinCondition && _gotScore > _maxScore / 2)
         {
             _starsWin = 3;

         }else if(_shootCount == _shootCountWinCondition + 1 || _shootCount == _shootCountWinCondition && _gotScore <= _maxScore / 2)
         {
             _starsWin = 2;           
         }
         else
         {
             _starsWin = 1;            
         }*/

        // CGameManager.Instance.mGameData.levelFinished(_starsWin);
        Debug.Log(_starsWin);
        StartCoroutine(WinCarutine(0.5f));
        
    }

    private IEnumerator WinCarutine(float deploy)
    {
        yield return new WaitForSeconds(deploy);
        _winSlot.SetActive(true);
    }

    private void WinSlotOn()
    {
        StartCoroutine(WinCarutine(0.5f));
    }
    
}

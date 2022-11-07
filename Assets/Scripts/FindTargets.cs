using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static FindTargets;

public class FindTargets : MonoBehaviour
{
    [SerializeField] private Text _levelTxt;
    [SerializeField] private Text _levelScoreTxt;
    [SerializeField] private Image[] _stars;
    [SerializeField] private int _currentLevel;
    private readonly string levelString = " Level";
    public Action winEvent, gotStarEvent;
    [SerializeField] private Target[] _targets;
    [SerializeField] private DisableObject[] _objects;
    private WinCondition _winCondition;
    [SerializeField] private GameObject[] _targetSlots;
    private List<Sprite> activeSpriteList;
    [SerializeField] private int[] maxCountTargetsArrey = new int[2]; 
   // private int[] currentCountTargetsArrey = new int[3];
    public List<ActualTarget> actualTargets;
    // private GameObject[] typesOfObjects;

    bool addbox;
    bool addPig;
    bool gotSecondStar;
    bool gotThirdStar;

    int typeCount = 0;
    [SerializeField] int _maxLevelScore;
    public int currentLevelScore;

    void Start()
    {
        actualTargets = new List<ActualTarget> { };        
        _targets = FindObjectsOfType<Target>();
       // _objects = FindObjectsOfType<DisableObject>();
        _winCondition = FindObjectOfType<WinCondition>();

        if(CGameManager.Instance!= null)
        {
            _currentLevel = CGameManager.Instance.mGameData.mActiveLevelId;
        }
        else
        {
            _currentLevel = 1;
        }
        
        _levelTxt.text = _currentLevel.ToString() + levelString;

        FindTargetsInScene();

       /* if(Stats.instance != null)
        {
            Stats.instance._updateLevelScoreUI += UpdateLevelScore;
        }*/

        for (int i = 0; i < _targets.Length; i++)
        {
          //  if (_targets[i].playerType == EPlayerType.Pig || _targets[i].playerType == EPlayerType.BoxBomb)
         //   {
                _targets[i].targetDieEvent += ChangeTargetInfo;
           // }
            _maxLevelScore += _currentLevel * 10 * _targets[i].Score;

        }

        if(_winCondition != null)
            _winCondition.GetMaxLevelScore(_maxLevelScore);

        
        StartCoroutine(GotStar(1, 0));

    }

    private void OnDestroy()
    {
        for (int i = 0; i < _targets.Length; i++)
        {
            if (_targets[i].playerType == EPlayerType.Pig || _targets[i].playerType == EPlayerType.BoxBomb)
            {
                _targets[i].targetDieEvent -= ChangeTargetInfo;
            }
            
        }

       // Stats.instance._updateLevelScoreUI -= UpdateLevelScore;
    }

   /* private void UpdateLevelScore()
    {
        _levelScoreTxt.text = Stats.instance.ScoreLevel.ToString();
        Debug.Log("invoke change text score");
    }*/

    private void FindTargetsInScene()
    {
        for (int i = 0; i < _targets.Length; i++)
        {
            if (_targets[i].playerType == EPlayerType.BoxBomb)
            {
                maxCountTargetsArrey[0]++;

                if (!addbox)
                {
                    addbox = true;
                    ActualTarget bombBox = new ActualTarget();
                    bombBox.type = EPlayerType.BoxBomb;
                    bombBox.targetIconSprite = Resources.Load<Sprite>("Targets/boxBomb");
                    bombBox.maxTargetCount = maxCountTargetsArrey[0];
                    actualTargets.Add(bombBox);
                }
                else
                {
                    for (int j = 0; j < actualTargets.Count; j++)
                    {
                        if (actualTargets[j].type == EPlayerType.BoxBomb)
                            actualTargets[j].maxTargetCount = maxCountTargetsArrey[0];
                    }
                }
            }
            else if (_targets[i].playerType == EPlayerType.Pig)
            {
                maxCountTargetsArrey[1]++;

                if (!addPig)
                {
                    addPig = true;
                    ActualTarget pig1 = new ActualTarget();
                    pig1.type = EPlayerType.Pig;
                    pig1.targetIconSprite = Resources.Load<Sprite>("Targets/pigHead");
                    pig1.maxTargetCount = maxCountTargetsArrey[1];
                    actualTargets.Add(pig1);
                }
                else
                {
                    for (int j = 0; j < actualTargets.Count; j++)
                    {
                        if (actualTargets[j].type == EPlayerType.Pig)
                            actualTargets[j].maxTargetCount = maxCountTargetsArrey[1];
                    }
                }
            }
           /* else if (_targets[i].playerType == EPlayerType.Pig2)
            {
                maxCountTargetsArrey[2]++;

                if (!addPig2)
                {
                    addPig2 = true;
                    ActualTarget pig2 = new ActualTarget();
                    pig2.type = EPlayerType.Pig2;
                    pig2.targetIconSprite = Resources.Load<Sprite>("Targets/pigHead");
                    pig2.maxTargetCount = maxCountTargetsArrey[2];
                    actualTargets.Add(pig2);
                }
                else
                {
                    for (int j = 0; j < actualTargets.Count; j++)
                    {
                        if (actualTargets[j].type == EPlayerType.Pig2)
                            actualTargets[j].maxTargetCount = maxCountTargetsArrey[2];
                    }

                }
            }*/
        }

        typeCount = actualTargets.Count;
        SetTargetsUI();


    }

    private void SetTargetsUI()
    {
        if (typeCount == 1)
        {
            _targetSlots[1].SetActive(true);
            _targetSlots[1].transform.GetChild(1).gameObject.SetActive(true);
            SetTargetCountInfo(_targetSlots, 1, 1, actualTargets, 0);
        }
        else if (typeCount == 2)
        {
            _targetSlots[0].SetActive(true);
            _targetSlots[0].transform.GetChild(0).gameObject.SetActive(true);
            _targetSlots[0].transform.GetChild(1).gameObject.SetActive(true);

            SetTargetCountInfo(_targetSlots, 0, 0, actualTargets, 0);
            SetTargetCountInfo(_targetSlots, 0, 1, actualTargets, 1);
        }
        /*else
        {
            _targetSlots[1].SetActive(true);
            _targetSlots[1].transform.GetChild(0).gameObject.SetActive(true);
            _targetSlots[1].transform.GetChild(1).gameObject.SetActive(true);
            _targetSlots[1].transform.GetChild(2).gameObject.SetActive(true);

            SetTargetCountInfo(_targetSlots, 1, 0, actualTargets, 0);
            SetTargetCountInfo(_targetSlots, 1, 1, actualTargets, 1);
            SetTargetCountInfo(_targetSlots, 1, 2, actualTargets, 2);
        }*/
    }

    private void SetTargetCountInfo(GameObject[] slot, int slotId, int childId, List<ActualTarget> _actualTargets, int _actualTargetsId)
    {
        slot[slotId].transform.GetChild(childId).gameObject.GetComponent<Image>().sprite =
                _actualTargets[_actualTargetsId].targetIconSprite;
        slot[slotId].transform.GetChild(childId).GetChild(0).gameObject.GetComponent<Text>().text =
            _actualTargets[_actualTargetsId].currentTargetDiedCount.ToString() + "/" + _actualTargets[_actualTargetsId].maxTargetCount.ToString();
    }


    public void ChangeTargetInfo(EPlayerType destriedObjectType, int objectScore)
    {
       // Debug.Log(objectScore);
       // objectScore *= _currentLevel * 10;
       // Debug.Log(objectScore);
        currentLevelScore += _currentLevel * 10 * objectScore;
        Debug.Log(currentLevelScore);
        _levelScoreTxt.text = currentLevelScore.ToString();
       // Debug.Log("invoke change text score");

        if(destriedObjectType == EPlayerType.Pig || destriedObjectType == EPlayerType.BoxBomb)
        {
            if (!gotSecondStar)
            {
                gotSecondStar = true;
                StartCoroutine(GotStar(1, 1));

            }


            int destroiedTargetsType = 0;
            Debug.Log("change info");
            for (int i = 0; i < actualTargets.Count; i++)
            {

                if (actualTargets[i].type == destriedObjectType)
                {
                    actualTargets[i].currentTargetDiedCount++;
                    SetTargetsUI();
                }

                if (actualTargets[i].currentTargetDiedCount == actualTargets[i].maxTargetCount)
                {
                    destroiedTargetsType++;

                    if (destroiedTargetsType == actualTargets.Count)
                    {

                        StartCoroutine(GotStar(1, 2));
                        StartCoroutine(WinCarutine(3));
                        Debug.Log("win ");
                    }
                }
            }
        }

        
    }

    private IEnumerator GotStar(float deley, int starNum)
    {
        yield return new WaitForSeconds(deley);
        gotStarEvent?.Invoke();
        _stars[starNum].color = new Color(_stars[starNum].color.r, _stars[starNum].color.g, _stars[starNum].color.b, 1f);
    }

    private IEnumerator WinCarutine(float deley)
    {
        yield return new WaitForSeconds(deley);
        winEvent?.Invoke();
    }

    [Serializable]
    public class ActualTarget
    {
        public Sprite targetIconSprite;
        public int maxTargetCount;
        public int currentTargetDiedCount = 0;
        public EPlayerType type;


    }
}

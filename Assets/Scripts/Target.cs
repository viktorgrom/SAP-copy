using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerType
{
    SceneObject,
    Pig,
    BoxBomb

}
public class Target : MonoBehaviour, ITargetable
{
    [Header("Target info")]
    public EPlayerType playerType;
    [SerializeField] private int _score;
    public int Score { get { return _score; } }
    public Sprite[] typeSpritesArrey;
    public event Action<EPlayerType, int> targetDieEvent;

    public void DieEvent()
    {
        targetDieEvent?.Invoke(playerType, Score);
       // Debug.Log(this.name + " die");
        // Stats.instance.ScorePlus(_score);
    }

    
}





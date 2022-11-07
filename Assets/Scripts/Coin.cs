using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private bool _chest;
    [SerializeField] private int _coin; 
    [SerializeField] private int _minRandomAmount; 
    [SerializeField] private int _maxRandomAmount;
    [SerializeField] private float _timerDisable;
    [SerializeField] private float _timerOffset;

    [SerializeField] private GameObject _effect;

    [SerializeField] private Renderer _renderer;

    void Start()
    {
        _coin = Random.Range(_minRandomAmount, _maxRandomAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stats.instance.ScorePlus(_coin);

        if (!_chest)
        {
            StartCoroutine(OffEffectCarutine(_timerDisable, _timerOffset));
        }
        
    }

    IEnumerator OffEffectCarutine(float timeDisable, float timeOffset)
    {
        yield return new WaitForSeconds(timeOffset);

        _effect.SetActive(true);
        _renderer.enabled = false;
        yield return new WaitForSeconds(timeDisable);

        this.gameObject.SetActive(false);



    }
}

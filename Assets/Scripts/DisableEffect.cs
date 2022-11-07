using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEffect : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _timer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            StartCoroutine(OffEffectCarutine(_timer));
        }
    }



    IEnumerator OffEffectCarutine(float time)
    {
        yield return new WaitForSeconds(time);
        _gameObject.SetActive(false);
    }
}

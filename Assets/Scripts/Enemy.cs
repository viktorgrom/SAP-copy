using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target, IAnimationable
{
    [Header("Enemy info")]
    [SerializeField] private float _health;
    [SerializeField] private GameObject _enemyRig;
    [SerializeField] private GameObject _enemyPng;
    [SerializeField] private GameObject _boomEffect;
    [SerializeField] private GameObject _dieEffect;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private ExplodeOnClick _explodeOnClick;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > _health || collision.gameObject.tag == "Bullet")
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            Die();
        }
    }



    IEnumerator Boom()
    {
        yield return new WaitForSeconds(0.2f);
        _explodeOnClick.ExplodeNow();
        _boomEffect.SetActive(true);
        base.DieEvent();


        if (_dieEffect != null)
            _dieEffect.SetActive(true);
    }

    public void Die()
    {
        if (_enemyRig != null)
        {
            Destroy(_rigidbody2D);

            //_rigidbody2D.isKinematic = true;
            _collider2D.enabled = false;
            _enemyRig.SetActive(false);
            _enemyPng.SetActive(true);
            StartCoroutine(Boom());
            // _enemyPng.GetComponent<ExplodeOnClick>().ExplodeNow();
            // _explodeOnClick.ExplodeNow();

            
        }



    }
}

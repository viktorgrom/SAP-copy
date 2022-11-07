using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTarger : Target
{
    [Header("Object info")]
    [SerializeField] private GameObject _effect;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;

    [SerializeField] private float _timerDisable;
    [SerializeField] private float _timerOffset;
    [SerializeField] private float _health;

    [SerializeField] private bool _explode;
    private Collider2D[] _colliders = null;
    [SerializeField] private float _explosionStrength;
    [SerializeField] private float _explosionRadius;
    private bool _nableToDestroy;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > _health)
        {
            
            _nableToDestroy = true;
            StartCoroutine(OffEffectCarutine(_timerDisable, _timerOffset));
        }

        /* if(collision.gameObject.tag == "Floor" && _nableToDestroy)
         {
             StartCoroutine(OffEffectCarutine(_timerDisable, _timerOffset));
         }*/
    }

    IEnumerator OffEffectCarutine(float timeDisable, float timeOffset)
    {
        
        yield return new WaitForSeconds(timeOffset);

        _effect.SetActive(true);

        if (_explode)
        {
            if (_rigidbody2D != null)
                Explode();
        }


        _renderer.enabled = false;
        _collider2D.enabled = false;
        Destroy(_rigidbody2D);

        yield return new WaitForSeconds(timeDisable);
        base.DieEvent();
        this.gameObject.SetActive(false);



    }

    private void Explode()
    {
        _colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (Collider2D o in _colliders)
        {
            if (o.gameObject.GetComponent<Rigidbody2D>() != null)
            //  if (_collider2D != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float explosionForce = _explosionStrength / distanceVector.magnitude;
                    o.GetComponent<Rigidbody2D>().AddForce(distanceVector.normalized * explosionForce);
                }
            }




        }
    }

    /* private void OnDrawGizmos()
     {
         Gizmos.DrawWireSphere(transform.position, _explosionRadius);
     }*/
}

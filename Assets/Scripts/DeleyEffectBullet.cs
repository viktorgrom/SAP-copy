using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleyEffectBullet : Bullet
{
    [SerializeField] private bool _explode;
    private Collider2D[] _colliders = null;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private float _explosionStrength;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private GameObject _boomEffect;
    [SerializeField] private GameObject _basicEffect;
    [SerializeField] private float _deleyToDiseble = 3f;
    [SerializeField] private float _deleyToExplore = 4f;

    
    void Start()
    {
        if (type == EBulletType.RedBomb)
        {
            StartCoroutine(DeleyExplore(_deleyToExplore, _deleyToDiseble));
        }
        
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type == EBulletType.Bomb)
        {
            
            StartCoroutine(DeleyExplore(_deleyToExplore, _deleyToDiseble));
            
        }
    }

    private IEnumerator DeleyExplore(float deleyExlpor, float deleyDiseble)
    {
        yield return new WaitForSeconds(deleyExlpor);
        _spriteRenderer.enabled = false;
        _basicEffect.SetActive(false);
        rigidbody2D.simulated = false;
        transform.rotation = Quaternion.identity;
        _boomEffect.SetActive(true);
                
        if (_explode)
        {
            if (rigidbody2D != null)
                Explode();
        }

        yield return new WaitForSeconds(deleyDiseble);
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

    private void OnDrawGizmos()
    {
      //  Gizmos.color = Color.green;
       // Gizmos.DrawSphere(transform.position, _explosionRadius);
    }
}

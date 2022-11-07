using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LineRenderer[] _lineRenderer;
    [SerializeField] Transform[] _stripPosition;
    [SerializeField] Transform _center;
    [SerializeField] Transform _idlePosition;

    public Vector3 _currentPosition;
    public float _maxLenght;
    public float _bottomBoundary;

    [SerializeField] bool _isMouseDown;


    public GameObject _bulletPrefab;
    Rigidbody2D _bulletRb;
    Collider2D _bulletCollider;

    public float _bulletPositionOffSet;

    public float force;

    void Start()
    {
        _lineRenderer[0].positionCount = 2;
        _lineRenderer[1].positionCount = 2;
        _lineRenderer[0].SetPosition(0, _stripPosition[0].position);
        _lineRenderer[1].SetPosition(0, _stripPosition[1].position);

        CreateBullet();

    }

    void Update()
    {
        if (_isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            _currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _currentPosition = _center.position + Vector3.ClampMagnitude(_currentPosition - _center.position, _maxLenght);

            _currentPosition = ClampBoundary(_currentPosition);

            SetStripts(_currentPosition);

            if (_bulletCollider)
            {
                _bulletCollider.enabled = true;
            }
        }
        else
        {
            ResetStripts();
        }
    }

    private void Shoot()
    {
        _bulletRb.isKinematic = false;
        Vector3 bulletForce = (_currentPosition - _center.position) * force * -1;
        _bulletRb.velocity = bulletForce;

        _bulletRb = null;
        _bulletCollider = null;

        Invoke("CreateBullet", 2);
    }

    private void CreateBullet()
    {
        _bulletRb = Instantiate(_bulletPrefab).GetComponent<Rigidbody2D>();
        _bulletCollider = _bulletRb.GetComponent<Collider2D>();
        _bulletCollider.enabled = false;

        _bulletRb.isKinematic = true;

        ResetStripts();

    }

    private Vector3 ClampBoundary(Vector3 currentPosition)
    {
        currentPosition.y = Mathf.Clamp(currentPosition.y, _bottomBoundary, 1000);
        return currentPosition;
    }

    private void OnMouseDown()
    {
        _isMouseDown = true;
    }

    private void OnMouseUp()
    {
        _isMouseDown = false;
        Shoot();
    }

    void ResetStripts()
    {
        _currentPosition = _idlePosition.position;
        SetStripts(_currentPosition);
    }

    void SetStripts(Vector3 position)
    {
        _lineRenderer[0].SetPosition(1, position);
        _lineRenderer[1].SetPosition(1, position);


        if (_bulletRb)
        {
            Vector3 dir = position - _center.position;
            _bulletRb.transform.position = position + dir.normalized * _bulletPositionOffSet;
            _bulletRb.transform.right = -dir.normalized;
        }
        
    }
}

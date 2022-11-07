using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMovable
{
    public enum EBulletType
    {
        Core,
        Bomb,
        RedBomb,
        Kastet

    }

    public EBulletType type;
    private Cannon _player;

    [SerializeField] public Rigidbody2D rigidbody2D;

    private float _firePower;
    private Vector3 _dir;

    void Start()
    {
        Move();

    }

    public void Move()
    {
        _player = FindObjectOfType<Cannon>();
        _firePower = _player.FirePower;
        Debug.Log(_firePower);
        _dir = _player._fireDirection;

        rigidbody2D.velocity = _dir * _firePower * 0.4f;
    }

   

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Bullet;

public class Cannon : MonoBehaviour
{
    private BulletChanger _bulletChanger;
    [SerializeField] bool _isMouseDown;
    
    private Vector3 _currentPosition;
    private Vector2 _touchPosition;
    private bool _disableCannonFire;
    Vector3 startPos;
    Vector3 currentTouchPos;
    [SerializeField] Transform _cannon;
    [SerializeField] Transform _barrel;
    
    [SerializeField] float _speed;
    [SerializeField] float _currentSpeed;
    public float direction = 1f; // initial direction
    [SerializeField] GameObject[] _bulletPrefab;
    public GameObject _selectedPrefab;


    public Vector3 _fireDirection;

    [SerializeField] private GameObject _firePositionGO;
    [SerializeField] private GameObject _backPositionGO;


    private Touch oneTouch, touchToMove, touchToFire;


    private float _firePower;

    [Header("Fire Effect")]
    [SerializeField] private GameObject _fireParticles1;
    [SerializeField] private GameObject _fireParticles2;
    private Vector3 _idleCannonPosition;
    private Vector3 _backCannonPosition;
    private Quaternion IdleRotation;
    private bool _backToIdleRorarion;
    [SerializeField] float _speedToIdleRot;
    [SerializeField] float _speedToBackPos;
    [SerializeField] float _speedToIdlePos;
    private float startTime;

    public event Action<bool> _readyToFire;
    public event Action _settingCannonUpEvent, _settingCannonDownEvent;
   // private bool _isSettingUp, _isSettingDown, _isSettingEnd;
    

    public float FirePower { get => _firePower = _firePower * _speed; set => _firePower = value; }

    void Start()
    {
        _bulletChanger = FindObjectOfType<BulletChanger>();
        _bulletChanger.selectedBulletTypeEvent += SelectBulletPrefab;

        _idleCannonPosition = _cannon.transform.position;

        _firePositionGO = GameObject.FindGameObjectWithTag("FirePosition");
        _backPositionGO = GameObject.FindGameObjectWithTag("BackPosition");
        IdleRotation = _barrel.localRotation;
        _backCannonPosition = new Vector3(_idleCannonPosition.x - 0.5f, _idleCannonPosition.y, _idleCannonPosition.z);

        

    }


    void Update()
    {
        if (Input.touchCount > 0 && !_disableCannonFire)
            MoveCannon();
        


        if (_backToIdleRorarion)
        {
            _disableCannonFire = true;
            _readyToFire?.Invoke(_disableCannonFire);
            _backToIdleRorarion = false;
            startTime = Time.time;
            _barrel.transform.rotation = Quaternion.Lerp(_barrel.transform.rotation, IdleRotation, _speedToIdleRot * Time.deltaTime);


            StartCoroutine(LerpPosition(_backCannonPosition, _idleCannonPosition, 0.6f, 2));
        }

    }

    IEnumerator LerpPosition(Vector2 backTargetPosition, Vector2 idlePosition, float durationBack,  float durationIdle)
    {
        float time = 0;
        Vector2 startPosition = _cannon.transform.position;
        while (time < durationBack)
        {
            _cannon.transform.position = Vector2.Lerp(startPosition, backTargetPosition, time / durationBack);
            time += Time.deltaTime;
            yield return null;
        }
        _cannon.transform.position = backTargetPosition;

        yield return new WaitForSeconds(durationBack);

        float time2 = 0;
        Vector2 startPosition2 = _cannon.transform.position;
        while (time2 < durationIdle)
        {
            _cannon.transform.position = Vector2.Lerp(startPosition2, idlePosition, time2 / durationIdle);
            time2 += Time.deltaTime;
            yield return null;
        }
        _cannon.transform.position = idlePosition;
        _fireParticles1.SetActive(false);
        _fireParticles2.SetActive(false);
        _disableCannonFire = false;
        _readyToFire?.Invoke(_disableCannonFire);
    }

    private void MoveCannon()
    {

        if (Input.touchCount == 1)
        {
            oneTouch = Input.GetTouch(0);

            if (oneTouch.position.x < Screen.width / 2)
            {
                if (oneTouch.phase == TouchPhase.Moved)
                {
                  //  _isSettingEnd = false;
                    float angle = _barrel.transform.eulerAngles.z;

                    if (oneTouch.deltaPosition.y > 0 && angle > 300 && angle <= 360 || oneTouch.deltaPosition.y > 0 && angle >= 0 && angle < 40f)
                    {
                        _barrel.transform.Rotate(0f, 0f, _speed * Time.deltaTime);
                       /* if (!_isSettingUp)
                        {
                            _isSettingUp = true;
                            _isSettingDown = false;
                            _settingCannonUpEvent?.Invoke();
                        }*/
                    }
                    else if (oneTouch.deltaPosition.y < 0 && angle > 330 && angle <= 360 || oneTouch.deltaPosition.y < 0 && angle >= 0 && angle < 70f)
                    {
                        _barrel.transform.Rotate(0f, 0f, -_speed * Time.deltaTime);

                       /* if (!_isSettingDown)
                        {
                            _isSettingDown = true;
                            _isSettingUp = false;
                            _settingCannonDownEvent?.Invoke();
                        }*/
                    }
                }
               /* else if(oneTouch.phase == TouchPhase.Ended)
                {
                    _isSettingEnd = true;
                }*/
            }
        }

    }


    private void MoveObject()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
          //  _touchPosition = touch.position;

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider.CompareTag("Player"))
            {
                _disableCannonFire = true; 
                Debug.Log("I'm hitting " + hit.collider.name);
            }

          //  if (_movePlayer)
          //  {
                if (touch.phase == TouchPhase.Began)
                {
                //    startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    currentTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                 //   float angle = _player.transform.eulerAngles.z;
               //     text.text = angle.ToString();
                //    if (startPos.y > currentTouchPos.y)
               //     {


                        /* if (angle > 180f) 
                             angle -= 360f;*/

                        /* if ((angle < -35f) || (angle > 45f)) 
                             direction *= -1f; */// reverse direction (toggles between 1 & -1)

                    //    if (angle < 45f)
                            _barrel.transform.Rotate(0, 0, touch.deltaPosition.y);
                
               //     }
                   /* else if (startPos.y < currentTouchPos.y)
                    {
                        if (angle > -35f)
                            _player.transform.Rotate(0, 0, _speed * direction * Time.deltaTime);
                    }*/
                }

              /*  if (touch.phase == TouchPhase.Ended)
                {
                //    _player.transform.position = _idleCannonPosition;
                    _movePlayer = false;
                }*/
          //  }
            
        }
        


       /* if (touch.phase == TouchPhase.Began)
        {
            Ray touchposition = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0f));
            RaycastHit2D hit = Physics2D.GetRayIntersection(touchposition);

            if (hit.collider.CompareTag("Player"))
            {
                _movePlayer = true;
                Debug.Log("touch cannon");
                Debug.Log("I'm hitting " + hit.collider.name);
            }
        }*/
       /*
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("I'm hitting " + hit.collider.name);
        }*/




    }

    private void GetFireDirection()
    {
        _fireDirection = _firePositionGO.transform.position - _backPositionGO.transform.position;
    }


    public void Fire(float power)
    {
        _firePower = power;
        if (power < 0.6f && power > 0.3f)
        {
            _fireParticles1.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            _fireParticles2.transform.localScale = new Vector3(1.3f, 1.3f, 1);
        }else if(power >= 0.6f)
        {
            _fireParticles1.transform.localScale = new Vector3(0.45f, 0.45f, 1);
            _fireParticles2.transform.localScale = new Vector3(1.6f, 1.6f, 1);
        }
        else
        {
            _fireParticles1.transform.localScale = new Vector3(0.25f, 0.25f, 1);
            _fireParticles2.transform.localScale = new Vector3(1f, 1f, 1);
        }
            
        _fireParticles1.SetActive(true);
        _fireParticles2.SetActive(true);
        
        GetFireDirection();
       
        GameObject bullet = Instantiate(_selectedPrefab);
        bullet.transform.position = _firePositionGO.transform.position;
        _backToIdleRorarion = true;
    }

    private void SelectBulletPrefab(EBulletType selectedBulletType)
    {
       // Debug.Log("Selected event " + selectedBulletType);
        for (int i = 0; i < _bulletPrefab.Length; i++)
        {
            if(_bulletPrefab[i].GetComponent<Bullet>().type == selectedBulletType)
            {
                _selectedPrefab = _bulletPrefab[i];
               // Debug.Log("Selected event " + _selectedPrefab.name);
            }
            
        }
        //_selectedPrefab
    }
}

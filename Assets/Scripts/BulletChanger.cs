using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static Bullet;
//using static System.Net.Mime.MediaTypeNames;

public class BulletChanger : MonoBehaviour
{
    private Cannon _cannon;
    private CannonFire cannonFire;
    public Action<EBulletType> selectedBulletTypeEvent;
    public Action noMoreBulletsEvent;
    public List<BulletUI> _bullets = new List<BulletUI>();
    [SerializeField] private Sprite[] numbersSprites = new Sprite[10];

    [SerializeField] private Slider _slider;
    [SerializeField] private Image _handle;
    [SerializeField] private Image _numberCountImg;
    [SerializeField] private int _startBulletIndex;
    [SerializeField] private int _selectedBulletIndex;
   // [SerializeField] private int _bulletTypeCount;
    [SerializeField] private GameObject _nextArrow;
    [SerializeField] private GameObject _previousArrow;
    [SerializeField] private GameObject _plusBtn;
    private Touch oneTouch;

    public EBulletType selectedBulletType;

    private int _allBulletCount;
    private int _currentBulletCount;

    void Start()
    {
        _cannon = FindObjectOfType<Cannon>();

        _cannon._readyToFire += EnableSlider;
        cannonFire = FindObjectOfType<CannonFire>();
        cannonFire._fireEventStart += DisableArrows;
        cannonFire._fireEventEnd += EnableArrows;
        // _bulletTypeCount = _bullets.Count;
        // _bullets = new List<BulletUI>();
        _selectedBulletIndex = _startBulletIndex;

        ChangeBulletUI(_selectedBulletIndex);
        _previousArrow.SetActive(false);
        _plusBtn.SetActive(false);

    }

    private void OnDestroy()
    {
        cannonFire._fireEventStart -= DisableArrows;
        cannonFire._fireEventEnd -= EnableArrows;
        _cannon._readyToFire -= EnableSlider;
    }

    /* private void MoveCannon()
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

                     text.text = oneTouch.deltaPosition.y.ToString();
                     text2.text = "Angle " + angle.ToString();

                     if (oneTouch.deltaPosition.y > 0 && angle > 300 && angle <= 360 || oneTouch.deltaPosition.y > 0 && angle >= 0 && angle < 40f)
                     {
                         _barrel.transform.Rotate(0f, 0f, _speed * Time.deltaTime);

                     }
                     else if (oneTouch.deltaPosition.y < 0 && angle > 330 && angle <= 360 || oneTouch.deltaPosition.y < 0 && angle >= 0 && angle < 70f)
                     {
                         _barrel.transform.Rotate(0f, 0f, -_speed * Time.deltaTime);


                     }
                 }

             }
         }

     }*/

    private void EnableSlider(bool disable)
    {
        if (disable)
        {
            _slider.interactable = false;

        }
        else
        {
            _slider.interactable = true;
            ChangeBulletUI(_selectedBulletIndex);
        }
    }

    private void EnableArrows()
    {
        _allBulletCount = 0;

        for (int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].bulletType == selectedBulletType)
            {
                _bullets[i].amount--;
            }

            _allBulletCount += _bullets[i].amount;

            if(_allBulletCount > 0)
            {
                return;
            }
            else
            {
                noMoreBulletsEvent?.Invoke();
            }
        }

        _numberCountImg.enabled = true;
        _nextArrow.SetActive(true);
        _previousArrow.SetActive(true);
       // Debug.Log(_selectedBulletIndex);
       // ChangeBulletUI(_selectedBulletIndex);
    }

    private void DisableArrows()
    {
        

        _numberCountImg.enabled = false;
        _nextArrow.SetActive(false);
        _previousArrow.SetActive(false);
        
    }



    public void NextBullet()
    {
        if(_selectedBulletIndex < _bullets.Count)
            _selectedBulletIndex++;

        ChangeBulletUI(_selectedBulletIndex);

    }

    public void PreviousBullet()
    {
        if (_selectedBulletIndex > 0)
            _selectedBulletIndex--;

        ChangeBulletUI(_selectedBulletIndex);

    }

    private void ChangeBulletUI(int index)
    {
        _handle.sprite = _bullets[index].spriteOfBullet;
        _numberCountImg.sprite = numbersSprites[_bullets[index].amount];
        selectedBulletType = _bullets[index].bulletType;

        selectedBulletTypeEvent?.Invoke(selectedBulletType);

        if (_bullets[index].amount > 0)
        {
            _slider.interactable = true;
            
        }
        else
        {
            _slider.interactable = false;
            _plusBtn.SetActive(true);
        }

        Debug.Log("change ui " + selectedBulletType);
        CheckArrows();
    }

    private void CheckArrows()
    {
        if (_bullets.Count > 1)
        {
            if (_selectedBulletIndex < _bullets.Count - 1)
            {
                _nextArrow.SetActive(true);
            }
            else
            {
                _nextArrow.SetActive(false);
            }

            if (_selectedBulletIndex > 0)
            {
                _previousArrow.SetActive(true);
            }
            else
            {
                _previousArrow.SetActive(false);
            }
        }
        else
        {
            _previousArrow.SetActive(false);
            _nextArrow.SetActive(false);
        }
    }


    [Serializable]
    public class BulletUI
    {
        public EBulletType bulletType;
        public int amount;
        public Sprite spriteOfBullet;
    }

    public void GotBullets(EBulletType eBulletType)
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].bulletType == eBulletType)
            {
                _bullets[i].amount++;
            }
        }
    }




}

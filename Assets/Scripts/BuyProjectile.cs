using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Bullet;

public class BuyProjectile : MonoBehaviour
{
    [SerializeField] private Button _buyBtn;
    private Cannon _cannon;
    private BulletChanger _bulletChanger;
    [SerializeField] private Image _bulletImage;
    [SerializeField] private Text _priceOfBullet;
    [SerializeField] private Text _currentMoneyAmount;
    [SerializeField] private int _currentMoneyAmountInt;
    [SerializeField] private int _priceOfBulletInt;

    [SerializeField] private GameObject _selectedBullet;
    private EBulletType eBulletType;

    void Start()
    {
        _cannon = FindObjectOfType<Cannon>();
        _bulletChanger = FindObjectOfType<BulletChanger>();
        _currentMoneyAmountInt = Stats.instance.Score;
        _currentMoneyAmount.text = _currentMoneyAmountInt.ToString();
        _priceOfBullet.text = _priceOfBulletInt.ToString();

        _selectedBullet = _cannon._selectedPrefab;
        _bulletImage.sprite = _selectedBullet.GetComponent<SpriteRenderer>().sprite;
        eBulletType = _selectedBullet.GetComponent<Bullet>().type;

        CheckActiveBuyBtn();
    }

    public void BuyBullet()
    {
        if(Stats.instance.Score >= _priceOfBulletInt)
        {
            _bulletChanger.GotBullets(eBulletType);
        }

        CheckActiveBuyBtn();
    }

    private void CheckActiveBuyBtn()
    {
        if (Stats.instance.Score >= _priceOfBulletInt)
        {
            _buyBtn.interactable = true;
        }
        else
        {
            _buyBtn.interactable = false;
        }
    }

}

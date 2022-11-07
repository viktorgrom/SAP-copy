using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CannonFire : MonoBehaviour
{

    private Cannon _cannon;
    
    [SerializeField] private Slider _slider;
    public event Action _fireEventEnd, _fireEventStart;
    private float _sliderValue;

    float _sliderPower;

    float _maxAlpha = 0.8f;
    float _minAlpha = 0.3f;

    [SerializeField] Image[] _imagesPower;

    bool _startedFire;

    private void Start()
    {
        _cannon = FindObjectOfType<Cannon>();
        
        

        _slider.value = 0f;

        for (int i = 0; i < _imagesPower.Length; i++)
        {
            var tempColor = _imagesPower[i].color;
            tempColor.a = _minAlpha;
            _imagesPower[i].color = tempColor;
        }

    }

    private void Update()
    {
        if (_slider.value > 0)
        {
            OnSliderChange();
            if( !_startedFire)
            {
                _startedFire = true;
                _fireEventStart?.Invoke();
            }
        }
    }

    private void OnSliderChange()
    {
        _sliderValue = _slider.value;
        float _sliderValueTemp = _sliderValue * 10;

        for (int i = 0; i < _imagesPower.Length; i++)
        {
            var tempColor = _imagesPower[i].color;

            if (_sliderValueTemp >= i)
            {                                
                tempColor.a = _maxAlpha;               
            }
            else
            {
                tempColor.a = _minAlpha;
            }

            _imagesPower[i].color = tempColor;
        }
    }

    public void StartFire()
    {
        StartCoroutine(CannonFireCarutine(3.5f));
    }

   

    IEnumerator CannonFireCarutine(float timer)
    {
        _fireEventEnd?.Invoke();
        _sliderPower = _slider.value;
        _slider.value = 0f;
        OnSliderChange();
        _slider.interactable = false;

        yield return new WaitForSeconds(timer);
       
        _cannon.Fire(_sliderPower);
        _startedFire = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private Animator _animator;
    private Cannon _cannon;
    private CannonFire _cannonFire;

    [SerializeField] private bool _setUp;
    [SerializeField] private bool _setDown;

    private void Start()
    {
        _animator = GetComponent<Animator>();
     //   _cannon = FindObjectOfType<Cannon>();
        _cannonFire = FindObjectOfType<CannonFire>();
      //  _cannon._settingCannonUpEvent += StickSettingUp;
       // _cannon._settingCannonDownEvent += StickSettingDown;
        _cannonFire._fireEventEnd += StickFireing;
    }

    public void StickSetting()
    {
        _animator.SetBool("isSetting", true);
    }

    public void StickSettingUp()
    {
       // _animator.SetBool("isSetttingUp", true);
        _setUp = true;
        _setDown = false;
    }

    public void StickSettingDown()
    {
       // _animator.SetBool("isSetttingUp", false);
        _setUp = false;
        _setDown = true;
    }

    public void StickFireing()
    {
        _animator.Play("Fire");
       // .SetBool("isFireing", true);
    }

}

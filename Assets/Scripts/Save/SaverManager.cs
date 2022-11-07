using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaverManager : MonoBehaviour
{
    public UnityEvent save;
    public UnityEvent load;

    public void SaveData()
    {
        save?.Invoke();
    }

    public void LoadData()
    {
        load?.Invoke();
    }



    private void Update()
    {
        if(Input.GetKey(KeyCode.F6))
            save?.Invoke();

        if (Input.GetKey(KeyCode.F7))
            load?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Start()
    {
        //DoMAth(1, 4);
        Debug.Log(DoMAth(4, 1));
    }

    public int DoMAth(int a, int b)
    {
        return (a < b ? a + b : a - b);
    }
}

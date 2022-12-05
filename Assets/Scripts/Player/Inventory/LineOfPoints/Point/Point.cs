using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private bool _isTaken = false;    

    public void Take()
    {
        _isTaken = true;
    }

    public bool CheckIsTaken()
    {
        if (_isTaken == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

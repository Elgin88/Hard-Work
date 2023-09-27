using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class DataForNextScene 
{
    private static int _money;

    public static int Money => _money;

    public static void SetMoney(int money)
    {
        _money = money;
    }
}
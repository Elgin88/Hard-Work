using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAfterStart : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;

    private void Update()
    {
        _time.text = Math.Round(Time.realtimeSinceStartup, 0).ToString();
    }
}

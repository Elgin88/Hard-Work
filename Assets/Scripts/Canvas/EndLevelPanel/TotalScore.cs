using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private CalculatorBlocks _calculatorBlocks;
    [SerializeField] private TMP_Text _label;

    private void OnEnable()
    {
        _label.text = _calculatorBlocks.Unload.ToString();
    }
}
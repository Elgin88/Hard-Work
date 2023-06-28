using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;

    private CalculatorBlocks _calculatorBlocks;    

    private void OnEnable()
    {
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
        _label.text = _calculatorBlocks.Unload.ToString();
    }
}
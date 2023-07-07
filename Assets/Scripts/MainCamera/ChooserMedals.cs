using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnderLevel))]
[RequireComponent(typeof(CalculatorBlocks))]

public class ChooserMedals : MonoBehaviour
{
    private EnderLevel _enderLevel;
    private CalculatorBlocks _calculatorBlocks;
    private bool _isMaxMedal = false;
    private bool _isMiddleMedal = false;
    private bool _isMinMedal = false;

    public bool IsMaxMedal => _isMaxMedal;
    public bool IsMiddleMedal => _isMiddleMedal;
    public bool IsMinMedal => _isMinMedal;

    public event UnityAction<bool, bool, bool> IsMedalsChoosen;

    private void OnEnable()
    {
        _enderLevel = GetComponent<EnderLevel>();
        _calculatorBlocks = GetComponent<CalculatorBlocks>();
    }

    public void ChooseMedals()
    {
        if (_calculatorBlocks.Unload >= _enderLevel.MinNumberBlocks)
        {
            _isMinMedal = true;            

            if (_calculatorBlocks.Unload >= _enderLevel.MiddleNumberBlocks)
            {
                _isMiddleMedal = true;

                if (_calculatorBlocks.Unload == _enderLevel.MaxNumberBlocks)
                {
                    _isMaxMedal = true;
                }
            }

            IsMedalsChoosen?.Invoke(_isMinMedal,_isMiddleMedal, _isMaxMedal);
        }
    }
}
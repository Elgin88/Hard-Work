using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooserMedals : MonoBehaviour
{
    private MaxMedal _maxMedal;
    private MiddleMedal _middleMedal;
    private MinMedal _minMedal;
    private EnderLevel _enderLevel;
    private CalculatorBlocks _calculatorBlocks;
    private GameRequireComponents _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
        _enderLevel = FindObjectOfType<EnderLevel>();
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();

        _maxMedal = _gameRequireComponents.MaxMedal;
        _middleMedal = _gameRequireComponents.MiddleMedal;
        _minMedal = _gameRequireComponents.MinMedal;
    }

    public void ChooseMedals()
    {
        if (_calculatorBlocks.Unload >= _enderLevel.MinNumberBlocks)
        {
            _minMedal.gameObject.SetActive(true);

            if (_calculatorBlocks.Unload >= _enderLevel.MiddleNumberBlocks)
            {
                _middleMedal.gameObject.SetActive(true);

                if (_calculatorBlocks.Unload == _enderLevel.MaxNumberBlocks)
                {
                    _maxMedal.gameObject.SetActive(true);
                }
            }
        }
    }
}
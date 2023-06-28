using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;

    private Slider _slider;
    private Coroutine _changeValue;
    private CalculatorBlocks _calculatorBlocks;
    private int _unloadBlocks;
    private int _allBlocks;
    private float _currentValue;
    private EnderLevel _endelLevel;

    public event UnityAction <bool, bool, bool > IsChangedValue;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
        _endelLevel = FindObjectOfType<EnderLevel>();

        

        _slider.value = 0;

        _calculatorBlocks.IsChangedNumberUnloadBlocks += OnChangedNumberBlocks;
    }

    private void OnDisable()
    {
        _calculatorBlocks.IsChangedNumberUnloadBlocks -= OnChangedNumberBlocks;
    }

    private void OnChangedNumberBlocks(int unloadBlocks)
    {
        if (_allBlocks == 0)
        {
            _allBlocks = _calculatorBlocks.AllBlocks;
        }        

        _unloadBlocks = unloadBlocks;

        StartChangeValue();
    }

    private IEnumerator ChangeValue()
    {
        while (true)
        {
            _currentValue = _slider.value;
            _slider.value = Mathf.MoveTowards(_currentValue, (float)_unloadBlocks / _allBlocks, _speedOfChange * Time.deltaTime);

            if (_slider.value > (float) _endelLevel.MinProcent / 100 & _slider.value < (float)_endelLevel.MiddleProcent / 100)
            {
                IsChangedValue?.Invoke(true, false, false);
            }

            if (_slider.value > (float)_endelLevel.MiddleProcent / 100 & _slider.value < (float)_endelLevel.MaxProcent / 100)
            {
                IsChangedValue?.Invoke(true, true, false);
            }

            if (_slider.value == 1)
            {
                IsChangedValue?.Invoke(true, true, true);
            }

            yield return null;
        }
    }

    private void StartChangeValue()
    {
        if (_changeValue == null)
        {
            _changeValue = StartCoroutine(ChangeValue());
        }
    }

    private void StopChangeValue()
    {
        if (_changeValue != null)
        {
            StopCoroutine(_changeValue);
            _changeValue = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;

    private Slider _slider;
    private Coroutine _changeValue;
    private CalculatorBlocks _calculatorBlocks;
    private int _unloadBlocks;
    private int _maxBlocks;
    private float _currentValue;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();

        _slider.value = 0;

        _calculatorBlocks.IsChangedUnload += OnChangedNumberBlocks;
    }

    private void OnDisable()
    {
        _calculatorBlocks.IsChangedUnload -= OnChangedNumberBlocks;
    }

    private void OnChangedNumberBlocks(int unloadBlocks, int maxBlocks)
    {
        _unloadBlocks = unloadBlocks;
        _maxBlocks = maxBlocks;

        StartChangeValue();
    }

    private IEnumerator ChangeValue()
    {
        while (true)
        {
            _currentValue = _slider.value;
            _slider.value = Mathf.MoveTowards(_currentValue, (float)_unloadBlocks / _maxBlocks, _speedOfChange * Time.deltaTime);

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
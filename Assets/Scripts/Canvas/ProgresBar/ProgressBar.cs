using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private string _labelMax;
    [SerializeField] private string _labelMiddle;
    [SerializeField] private string _labelMin;
    [SerializeField] private float _speedOfChange;

    private Slider _slider;
    private TMP_Text _max;
    private TMP_Text _middle;
    private TMP_Text _min;
    private Coroutine _changeValue;
    private CalculatorBlocks _calculatorBlocks;
    private int _unloadBlocks;
    private int _maxBlocks;
    private float _currentValue;

    private void OnEnable()
    {
        _max = GetComponentInChildren<ProgressBarMax>().GetComponent<TMP_Text>();
        _middle = GetComponentInChildren<ProgressBarMiddle>().GetComponent<TMP_Text>();
        _min = GetComponentInChildren<ProgressBarMin>().GetComponent<TMP_Text>();
        _slider = GetComponent<Slider>();
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();

        _max.text = _labelMax;
        _middle.text = _labelMiddle;
        _min.text = _labelMin;

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
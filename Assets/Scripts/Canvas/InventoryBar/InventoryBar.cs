using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class InventoryBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;

    private Slider _slider;
    private TMP_Text _maxText;
    private TMP_Text _middleText;
    private TMP_Text _minText;
    private Inventory _inventory;
    private Coroutine _changeValue;
    private LineOfPointsCreater _lineOfPointsCreater;
    private LineOfPoints _lineOfPoints;
    private float _currentSliderValue;
    private float _targetSliderValue;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _lineOfPoints = FindObjectOfType<LineOfPoints>();

        int maxNumberBlocks = _player.MaxHightOfInventory * _lineOfPoints.NumberPoints;

        _maxText.text = maxNumberBlocks.ToString();
        _middleText.text = (maxNumberBlocks / 2).ToString();
        _minText.text = "0";
    }

    private void OnEnable()
    {
        _lineOfPointsCreater = FindObjectOfType<LineOfPointsCreater>();
        _inventory = FindObjectOfType<Inventory>();

        _slider = GetComponent<Slider>();
        _maxText = GetComponentInChildren<InventoryBarMax>().GetComponent<TMP_Text>();
        _middleText = GetComponentInChildren<InventoryBarMiddle>().GetComponent<TMP_Text>();
        _minText = GetComponentInChildren<InventoryBarMin>().GetComponent<TMP_Text>();        

        _slider.value = 0;
        _inventory.IsChangedNumberBlocks += OnChangedNumberBlocks;
        _lineOfPointsCreater.IsChangedMaxNumberBlocks += OnChangedMaxNumberBlocks;
    }

    private void OnDisable()
    {
        _inventory.IsChangedNumberBlocks -= OnChangedNumberBlocks;
        _lineOfPointsCreater.IsChangedMaxNumberBlocks -= OnChangedMaxNumberBlocks;
    }

    private void OnChangedNumberBlocks(int target, int max)
    {
        _targetSliderValue = (float) target / max;

        StartChangeValue();
    }

    private IEnumerator ChangeValue()
    {
        while (true)
        {
            _currentSliderValue = _slider.value;

            _slider.value = Mathf.MoveTowards(_currentSliderValue, _targetSliderValue, _speedOfChange * Time.deltaTime);

            if (_slider.value == _targetSliderValue)
            {
                StopChangeValue();
            }

            yield return null;
        }
    }

    private void OnChangedMaxNumberBlocks(int current, int max)
    {
        _maxText.text = max.ToString();
        _middleText.text = (max / 2).ToString();
    }

    public void StartChangeValue()
    {
        if (_changeValue == null)
        {
            _changeValue = StartCoroutine(ChangeValue());
        }
    }

    public void StopChangeValue()
    {
        if (_changeValue != null)
        {
            StopCoroutine(_changeValue);
            _changeValue = null;
        }
    }
}
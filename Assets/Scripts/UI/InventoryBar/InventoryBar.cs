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
    private TMP_Text _max;
    private TMP_Text _middle;
    private TMP_Text _min;
    private Inventory _inventory;
    private Coroutine _changeValue;
    private LineOfPointsCreater _lineOfPointsCreater;

    private float _currentSliderValue;
    private float _targetSliderValue;

    private void Start()
    {
        _slider.value = 0;
        _max.text = _inventory.GetMaxNumberOfBlocks().ToString();
        _middle.text = (_inventory.GetMaxNumberOfBlocks()/2).ToString();

        _min.text = "0";
    }

    private void OnEnable()
    {
        if (_slider == null || _max == null || _middle == null || _min == null || _inventory == null || _lineOfPointsCreater == null)
        {
            _slider = GetComponent<Slider>();
            _max = GetComponentInChildren<InventoryBarMax>().GetComponent<TMP_Text>();
            _middle = GetComponentInChildren<InventoryBarMiddle>().GetComponent<TMP_Text>();
            _min = GetComponentInChildren<InventoryBarMin>().GetComponent<TMP_Text>();
            _inventory = FindObjectOfType<Inventory>();
            _lineOfPointsCreater = FindObjectOfType<LineOfPointsCreater>();
        }

        _inventory.IsAddedBlock += OnChangedNumberBlocks;
        _lineOfPointsCreater.IsChangedMaxNumberBlocks += OnChangedMaxNumberBlocks;
    }

    private void OnDisable()
    {
        _inventory.IsAddedBlock -= OnChangedNumberBlocks;
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
        _max.text = max.ToString();
        _middle.text = (max / 2).ToString();
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
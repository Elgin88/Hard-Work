using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class FuelBar : MonoBehaviour
{
    [SerializeField] private float _speedOfChange;
    private TMP_Text _max;
    private TMP_Text _middle;
    private TMP_Text _min;

    private Slider _slider;
    private PlayerFuelController _fuelController;
    private Coroutine _changeSliderValue;
    private float _currentValue;
    private float _targetFuel;
    private float _maxFuel;
    private GameRequireComponents _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
        _fuelController = FindObjectOfType<PlayerFuelController>();

        _max = _gameRequireComponents.MaxFuelBar.GetComponent<TMP_Text>();
        _middle = _gameRequireComponents.MiddleFuelBar.GetComponent<TMP_Text>();
        _min = _gameRequireComponents.MinFuelBar.GetComponent<TMP_Text>();
        
        _slider = GetComponent<Slider>();

        _slider.value = 0;
        _fuelController.IsFuelChanged += OnFuelChanged;
    }

    private void OnDisable()
    {
        _fuelController.IsFuelChanged -= OnFuelChanged;
    }

    private void OnFuelChanged(float target, float max)
    {
        _targetFuel = target;
        _maxFuel = max;

        _max.text = max.ToString();
        _middle.text = (max/2).ToString();
        _min.text = "0";

        StartChangeSliderValue();
    }

    private IEnumerator ChangeSliderValue()
    {
        while (true)
        {
            _currentValue = _slider.value;

            _slider.value = Mathf.MoveTowards(_currentValue, _targetFuel/ _maxFuel, _speedOfChange * Time.deltaTime);

            if (_slider.value == _targetFuel / _maxFuel)
            {
                StopChangeSliderValue();
            }

            yield return null;
        }
    }

    private void StartChangeSliderValue()
    {
        if (_changeSliderValue == null)
        {
            _changeSliderValue = StartCoroutine(ChangeSliderValue());
        }
    }

    private void StopChangeSliderValue()
    {
        if (_changeSliderValue != null)
        {
            StopCoroutine(_changeSliderValue);
            _changeSliderValue = null;
        }
    }
}
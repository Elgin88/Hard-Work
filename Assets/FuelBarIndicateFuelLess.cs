using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class FuelBarIndicateFuelLess : MonoBehaviour
{
    [SerializeField] private float _minLevelForIndicate;
    [SerializeField] private float _duration;
    [SerializeField] private float _deltaScale;

    private PlayerFuelController _fuelController;
    private RectTransform _rectTransform;
    private Coroutine _flash;
    private Vector3 _startStale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private float _currentFuel;
    private float _maxFuel;
    private float _delta;

    private void OnEnable()
    {
        _fuelController = FindObjectOfType<PlayerFuelController>();
        _rectTransform = GetComponent<RectTransform>();

        _startStale = _rectTransform.localScale;

        _currentScale = _startStale;

        _targetScale.x = _startStale.x + _deltaScale;
        _targetScale.y = _startStale.y + _deltaScale;
        _targetScale.z = _startStale.z + _deltaScale;

        _delta = _deltaScale / (_duration / 2 / Time.deltaTime);

        _fuelController.IsFuelChanged += OnFuelChanged;
    } 

    private void OnDisable()
    {
        _fuelController.IsFuelChanged -= OnFuelChanged;
    }

    private void OnFuelChanged(float current, float max)
    {
        _currentFuel = current;
        _maxFuel = max;

        if (_currentFuel / _maxFuel < _minLevelForIndicate)
        {
            StartFlash();
        }
    }

    private IEnumerator Flash()
    {
        bool isBack = false;

        while (true)
        {
            if (_currentScale.x < _targetScale.x & isBack == false)
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _delta);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _delta);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _delta);
            }
            else
            {
                isBack = true;
            }

            if (_currentScale.x > _startStale.x & isBack == true)
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startStale.x, _delta);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startStale.y, _delta);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startStale.z, _delta);
            }
            else
            {
                isBack = false;
            }

            if (_currentFuel/_maxFuel > _minLevelForIndicate)
            {
                StopCoroutine(_flash);
            }

            _rectTransform.localScale = _currentScale;

            yield return null;
        }
    }

    private void StartFlash()
    {
        if (_flash == null)
        {
            _flash = StartCoroutine(Flash());
        }
    }

    private void StopFlash()
    {
        if (_flash != null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}
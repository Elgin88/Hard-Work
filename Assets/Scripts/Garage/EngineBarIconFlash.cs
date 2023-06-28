using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class EngineBarIconFlash : MonoBehaviour
{
    private EngineBarIconController _controller;
    private RectTransform _rectTransform;
    private Coroutine _flash;

    private float _maxScaleX;
    private float _maxScaleY;
    private float _maxScaleZ;
    private float _duration;

    private float _startScaleX;
    private float _startScaleY;
    private float _startScaleZ;

    private float _currentScaleX;
    private float _currentScaleY;
    private float _currentScaleZ;

    private float _deltaX;
    private float _deltaY;
    private float _deltaZ;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        _controller = GetComponentInParent<EngineBarIconController>();

        _startScaleX = _rectTransform.localScale.x;
        _startScaleY = _rectTransform.localScale.y;
        _startScaleZ = _rectTransform.localScale.z;

        _currentScaleX = _startScaleX;
        _currentScaleY = _startScaleY;
        _currentScaleZ = _startScaleZ;

        _maxScaleX = _controller.MaxScaleX;
        _maxScaleY = _controller.MaxScaleY;
        _maxScaleZ = _controller.MaxScaleZ;
        _duration = _controller.Duration;

        _deltaX = (_maxScaleX - _startScaleX) / _duration/2 * Time.deltaTime;
        _deltaY = (_maxScaleY - _startScaleY) / _duration/2 * Time.deltaTime;
        _deltaZ = (_maxScaleZ - _startScaleZ) / _duration/2 * Time.deltaTime;
    }

    private IEnumerator Flash()
    {
        bool isForward = true;

        while (true)
        {
            if (isForward)
            {
                _currentScaleX = Mathf.MoveTowards(_currentScaleX, _maxScaleX, _deltaX);
                _currentScaleY = Mathf.MoveTowards(_currentScaleY, _maxScaleY, _deltaY);
                _currentScaleZ = Mathf.MoveTowards(_currentScaleZ, _maxScaleZ, _deltaZ);

                _rectTransform.localScale = new Vector3(_currentScaleX, _currentScaleY, _currentScaleZ);

                if (_currentScaleX == _maxScaleX & _currentScaleY == _maxScaleY & _currentScaleZ == _maxScaleZ)
                    isForward = false;
            }
            else
            {
                _currentScaleX = Mathf.MoveTowards(_currentScaleX, _startScaleX, _deltaX);
                _currentScaleY = Mathf.MoveTowards(_currentScaleY, _startScaleY, _deltaY);
                _currentScaleZ = Mathf.MoveTowards(_currentScaleZ, _startScaleZ, _deltaZ);

                _rectTransform.localScale = new Vector3(_currentScaleX, _currentScaleY, _currentScaleZ);

                if (_currentScaleX == _startScaleX & _currentScaleY == _startScaleY & _currentScaleZ == _startScaleZ)
                    StopFlash();
            }

            yield return null;
        }       
    }

    public void StartFlash()
    {
        if (_flash == null)
        {
            _flash = StartCoroutine(Flash());
        }
    }

    public void StopFlash()
    {
        if (_flash != null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class EndLevelButtonFlash : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    [SerializeField] private float _speedOfFlash;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;

    private RectTransform _rectTransform;
    private Coroutine _flash;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = new Vector3(_startScale.x + _deltaScale, _startScale.y + _deltaScale, _startScale.z + _deltaScale);

        StartFlash();
    }

    private void OnDisable()
    {
        StopFlash();
    }

    private IEnumerator Flash()
    {
        bool isForward = true;

        while (true)
        {
            if (isForward)
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _speedOfFlash * Time.deltaTime);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _speedOfFlash * Time.deltaTime);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _speedOfFlash * Time.deltaTime);

                if (_currentScale.x>= _targetScale.x)
                {
                    isForward = false;
                }
            }

            else
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _speedOfFlash * Time.deltaTime);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _speedOfFlash * Time.deltaTime);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _speedOfFlash * Time.deltaTime);

                if (_currentScale.x <= _startScale.x)
                {
                    isForward = true;
                }
            }

            _rectTransform.localScale = _currentScale;

            yield return null;
        }
    }

    private void  StartFlash()
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
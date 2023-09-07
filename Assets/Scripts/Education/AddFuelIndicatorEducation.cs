using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuelIndicatorEducation : MonoBehaviour
{
    private GarageIndicatorEducation[] _garageIndicatorsEducation;

    private float _deltaScaleInPercentages = 30;
    private float _timeOfFlashInSeconds = 0.3f;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale => _startScale * (100 + _deltaScaleInPercentages) / 100;

    private Coroutine _flash;

    private float _deltaScale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

    private void OnEnable()
    {
        if (_garageIndicatorsEducation == null)
        {
            _garageIndicatorsEducation = FindObjectsOfType<GarageIndicatorEducation>();

            foreach (var indicator in _garageIndicatorsEducation)
            {
                indicator.gameObject.SetActive(false);
            }
        }

        StartFlash();
    }

    private void OnDisable()
    {
        StopFlash();

        transform.localScale = _startScale;
    }

    private IEnumerator Flash()
    {
        bool isForward = true;

        _startScale = transform.localScale;
        _currentScale = _startScale;

        while (true)
        {
            if (isForward)
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaScale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaScale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaScale);

                if (_currentScale.x == _targetScale.x)
                {
                    isForward = false;
                }
            }
            else
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _deltaScale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _deltaScale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _deltaScale);

                if (_currentScale.x == _startScale.x)
                {
                    isForward = true;
                }
            }

            transform.localScale = _currentScale;

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
        if (_flash!=null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}

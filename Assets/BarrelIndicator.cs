using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]

public class BarrelIndicator : MonoBehaviour
{
    private float _deltaScaleInPercentages = 30;
    private float _timeOfFlashInSeconds = 1;

    private Coroutine _flash;
    private Transform _transform;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;

    private float _deltaScale;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        _startScale = _transform.localScale;
    }

    private IEnumerator Flash()
    {
        while (true)
        {
            _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaScale);
            _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaScale);
            _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaScale);

            _transform.localScale = _currentScale;

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
        StopCoroutine(_flash);
        _flash = null;
    }
}

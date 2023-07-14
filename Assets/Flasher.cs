using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(RectTransform))]

public class Flasher : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _range;

    private RectTransform _rectTransform;
    private Coroutine _flash;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private float _deltaScale;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = new Vector3(_startScale.x + _range, _startScale.y + _range, _startScale.z + _range);

        _deltaScale = _range / (0.5f * _duration / Time.deltaTime);
    }

    private IEnumerator Flash()
    {
        bool isForward = true;

        while (true)
        {
            if (isForward)
            {
                ChangeScale(_currentScale, _targetScale);

                if (_currentScale.x >= _targetScale.x)
                    isForward = false;}
            else
            {
                ChangeScale(_currentScale, _startScale);

                if (_currentScale.x <= _startScale.x)
                    StopFlash();
            }

            yield return null;
        }
    }

    private void ChangeScale(Vector3 startScale, Vector3 targetScale)
    {
        _currentScale.x = Mathf.MoveTowards(startScale.x, targetScale.x, _deltaScale);
        _currentScale.y = Mathf.MoveTowards(startScale.y, targetScale.y, _deltaScale);
        _currentScale.z = Mathf.MoveTowards(startScale.z, targetScale.z, _deltaScale);

        _rectTransform.localScale = new Vector3(_currentScale.x, _currentScale.y, _currentScale.z);
    }

    public void StartFlash()
    {
        if (_flash == null)
            _flash = StartCoroutine(Flash());
    }

    public void StopFlash()
    {
        StopCoroutine(_flash);
        _flash = null;
    }
}

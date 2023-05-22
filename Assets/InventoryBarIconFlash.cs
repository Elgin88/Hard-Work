using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]

public class InventoryBarIconFlash : MonoBehaviour
{
    [SerializeField] private float _deltaScale;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;

    private RectTransform _rectTransform;
    private Inventory _inventory;
    private Coroutine _flash;
    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private Color _startColor;
    private Image _image;
    private float _deltaScaleCalculated;

    private void OnEnable()
    {
        _inventory = FindObjectOfType<Inventory>();
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        _startColor = _image.color;

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = new Vector3(_startScale.x + _deltaScale, _startScale.y + _deltaScale, _startScale.z);

        _deltaScaleCalculated = _deltaScale / _duration / 2 / Time.deltaTime;

        _inventory.IsChangedNumberBlocks += OnChangedNumberBlocksInInventory;
    }

    private void OnDisable()
    {
        _inventory.IsChangedNumberBlocks -= OnChangedNumberBlocksInInventory;
    }

    private void OnChangedNumberBlocksInInventory(int current, int max)
    {
        if (current == max)
        {
            StartFlash();
        }
    }

    private IEnumerator Flash()
    {
        bool isBack = false;

        while (true)
        {
            Debug.Log(_startScale);
            Debug.Log(_currentScale);
            Debug.Log(_targetScale);
            Debug.Log(isBack);
            Debug.Log("===============");

            if (_currentScale.x < _targetScale.x & isBack == false)
            {
                _image.CrossFadeColor(_targetColor, _duration / 2, false, false);

                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaScaleCalculated);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaScaleCalculated);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaScaleCalculated);
            }
            else if(_currentScale.x == _targetScale.x & isBack == false)
            {
                isBack = true;
            }

            if (_currentScale.x > _startScale.x & isBack == true)
            {
                _image.CrossFadeColor(_startColor, _duration / 2, false, false);

                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _deltaScaleCalculated);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _deltaScaleCalculated);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _deltaScaleCalculated);
            }
            else if(_currentScale.x == _startScale.x & isBack == true)
            {
                StopCoroutine();
            }            

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

    private void StopCoroutine()
    {
        if (_flash!=null)
        {
            StopCoroutine(_flash);
            _flash = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Transform))]

public class BarrelIndicatorEducation : MonoBehaviour
{
    [SerializeField] private CollectorIndicatorEducation[] _collectorIndicators;

    private ChooserMedals _chooserMedals;
    private EnderLevel _enderLevel;
    private Inventory _inventory;
    private CalculatorBlocks _calculatorBlocks;

    private float _deltaScaleInPercentages = 30;
    private float _timeOfFlashInSeconds = 0.3f;

    private Coroutine _flash;
    private Transform _transform;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;

    private float _deltaScale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_chooserMedals == null)
        {
            _chooserMedals = FindObjectOfType<ChooserMedals>();
            _enderLevel = FindObjectOfType<EnderLevel>();
            _inventory = FindObjectOfType<Inventory>();
            _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
        }

        _transform = GetComponent<Transform>();

        _startScale = _transform.localScale;
        _currentScale = _startScale;
        _targetScale = _startScale * (100 +_deltaScaleInPercentages) / 100;

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
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaScale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaScale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaScale);

                if (_currentScale.x >= _targetScale.x)
                {
                    isForward = false;
                }
            }
            else 
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _deltaScale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _deltaScale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _deltaScale);

                if (_currentScale.x <= _startScale.x)
                {
                    isForward = true;
                }
            }

            _transform.localScale = _currentScale;

            float currentProcent = ((float)_inventory.GetCurrentCountOfBlocks() / ((float)_calculatorBlocks.AllBlocks + 1)) * 100;

            if (currentProcent > _enderLevel.MinProcent)
            {
                foreach (var indicator in _collectorIndicators)
                {
                    indicator.gameObject.SetActive(true);
                }

                gameObject.SetActive(false);
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
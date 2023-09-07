using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]

public class JoystickIndicatorEducation : MonoBehaviour
{
    [SerializeField]private BarrelIndicatorEducation[] _barrelIndicators;

    private AddFuelIndicatorEducation[] _addFuelIndicators;
    private CollectorIndicatorEducation[] _collectorIndicators;
    private GarageIndicatorEducation[] _garageIndicators;
    private JoystickIndicatorEducation[] _joystickIndicators;
    private EndLevelButtonIndicatorEducation[] _endLevelButtonIndicatorEducation;
    private FixedJoystick _fixedJoystick;
    private PlayerSpeedSetter _playerSpeedSetter;
    private CanvasUI _canvasUI;

    private string _levelName = "Level1";
    private float _deltaRangeInProcent = 30;
    private float _timeOfFlashInSeconds = 0.3f;
    private float _timeToOffIndicatorByPress = 0.8f;

    private RectTransform _rectTransform;
    private Coroutine _flash;
    private Scene _currentScene;
    private float _currentPressTime;

    private Vector3 _startScale;
    private Vector3 _currentScale;
    private Vector3 _targetScale;
    private bool _isNeedBarrelsIndicators = true;

    private float _deltaSclale => (_targetScale.x - _startScale.x) / (_timeOfFlashInSeconds / Time.deltaTime);

    private void OnEnable()
    {
        _currentScene = SceneManager.GetActiveScene();

        if (_currentScene.name != _levelName)
        {
            gameObject.SetActive(false);
            return;
        }

        if (_addFuelIndicators == null)
        {
            _addFuelIndicators = FindObjectsOfType<AddFuelIndicatorEducation>();
            _collectorIndicators = FindObjectsOfType<CollectorIndicatorEducation>();
            _garageIndicators = FindObjectsOfType<GarageIndicatorEducation>();
            _joystickIndicators = FindObjectOfType<CanvasUI>().JoystickIndicators;
            _playerSpeedSetter = FindObjectOfType<PlayerSpeedSetter>();
            _canvasUI = FindObjectOfType<CanvasUI>();
        }

        _rectTransform = GetComponent<RectTransform>();

        _startScale = _rectTransform.localScale;
        _currentScale = _startScale;
        _targetScale = _startScale + _startScale * _deltaRangeInProcent/100;

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
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _targetScale.x, _deltaSclale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _targetScale.y, _deltaSclale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _targetScale.z, _deltaSclale);

                if (_currentScale.x >= _targetScale.x)
                {
                    isForward = false;
                }
            }
            else
            {
                _currentScale.x = Mathf.MoveTowards(_currentScale.x, _startScale.x, _deltaSclale);
                _currentScale.y = Mathf.MoveTowards(_currentScale.y, _startScale.y, _deltaSclale);
                _currentScale.z = Mathf.MoveTowards(_currentScale.z, _startScale.z, _deltaSclale);

                if (_currentScale.x <= _startScale.x)
                {
                    isForward = true ;
                }
            }

            _rectTransform.localScale = _currentScale;

            CalculatePressingTimeOfJoystick();

            if (_currentPressTime >_timeToOffIndicatorByPress && _isNeedBarrelsIndicators)
            {
                EnableBarrelIndicators();
                _isNeedBarrelsIndicators = false;
                gameObject.SetActive(false);
                _currentPressTime = 0;
            }

            if (_currentPressTime > _timeToOffIndicatorByPress && _isNeedBarrelsIndicators == false)
            {
                EnableEndLevelButtonIndicatorsEducaton();
                _currentPressTime = 0;
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void EnableBarrelIndicators()
    {
        if (_barrelIndicators != null)
        {
            foreach (var indicator in _barrelIndicators)
            {
                indicator.gameObject.SetActive(true);
                indicator.StartFlash();
            }
        }      
    }

    private void EnableEndLevelButtonIndicatorsEducaton()
    {
        if (_canvasUI.AddFuelIndicators!=null)
        {
            foreach (var indicator in _canvasUI.EndLevelButtonIndicatorEducation)
            {
                indicator.gameObject.SetActive(true);
            }
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

    private void CalculatePressingTimeOfJoystick()
    {
        if (_playerSpeedSetter.CurrentSpeed > 1)
        {
            _currentPressTime += Time.deltaTime;
        }
        else
        {
            _currentPressTime = 0;
        }
    }
}
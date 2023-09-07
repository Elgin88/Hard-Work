using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelButtonIndicatorEducation : MonoBehaviour
{
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

        _rectTransform = GetComponent<RectTransform>();

        _startScale = _rectTransform.localScale;
        _targetScale = _startScale + _startScale * _deltaRangeInProcent / 100;
        _currentScale = _targetScale;

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
                    isForward = true;
                }
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

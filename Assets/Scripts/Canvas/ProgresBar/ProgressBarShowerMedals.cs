using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]

public class ProgressBarShowerMedals : MonoBehaviour
{
    [SerializeField] private MinMedalUI _minMedalUI;
    [SerializeField] private MiddleMedalUI _middleMedalUI;
    [SerializeField] private MaxMedalUI _maxMedalUI;

    private ProgressBar _progressBar;

    private void OnEnable()
    {
        if (_progressBar == null)
        {
            _progressBar = GetComponent<ProgressBar>();
        }

        _progressBar.IsChangedValue += OnChangedSliderValue;
    }

    private void OnDisable()
    {
        _progressBar.IsChangedValue -= OnChangedSliderValue;
    }

    private void OnChangedSliderValue(bool isMin, bool isMiddle, bool isMax)
    {
        bool isMinEnabled = false ;
        bool isMiddleEnabled = false;
        bool isMaxEnabled = false;

        if (isMin == true & isMinEnabled == false)
        {
            _minMedalUI.gameObject.SetActive(true);
            isMinEnabled = true;
        }

        if (isMiddle == true & isMiddleEnabled == false)
        {
            _middleMedalUI.gameObject.SetActive(true);
            isMiddleEnabled = true;
        }

        if (isMax == true & isMaxEnabled == false)
        {
            _maxMedalUI.gameObject.SetActive(true);
            isMaxEnabled = true;
        }
    }
}

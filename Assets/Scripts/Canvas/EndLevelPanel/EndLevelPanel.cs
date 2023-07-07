using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelPanel : MonoBehaviour
{
    [SerializeField] private MinMedal _minMedal;
    [SerializeField] private MiddleMedal _middleMedal;
    [SerializeField] private MaxMedal _maxMedal;

    private ChooserMedals _chooserMedal;

    private void OnEnable()
    {
        _chooserMedal = FindObjectOfType<ChooserMedals>();

        OpenPanels(_chooserMedal.IsMinMedal, _chooserMedal.IsMiddleMedal, _chooserMedal.IsMaxMedal);
        _chooserMedal.IsMedalsChoosen += OnMedalsChoosen;
    }

    private void OnDisable()
    {
        _chooserMedal.IsMedalsChoosen -= OnMedalsChoosen;
    }

    private void OnMedalsChoosen(bool isMin, bool isMiddle, bool isMax)
    {
        OpenPanels(isMin, isMiddle, isMax);
    }

    private void OpenPanels(bool isMin, bool isMiddle, bool isMax)
    {
        bool isMinEnabled = false;
        bool isMiddleEnabled = false;
        bool isMaxEnabled = false;

        if (isMin == true & isMinEnabled == false)
        {
            _minMedal.gameObject.SetActive(true);
            isMinEnabled = true;
        }

        if (isMiddle == true & isMiddleEnabled == false)
        {
            _middleMedal.gameObject.SetActive(true);
            isMiddleEnabled = true;
        }

        if (isMax == true & isMaxEnabled == false)
        {
            _maxMedal.gameObject.SetActive(true);
            isMaxEnabled = true;
        }
    }
}

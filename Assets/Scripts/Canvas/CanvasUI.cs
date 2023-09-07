using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicators;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicators;
    [SerializeField] private EndLevelButtonIndicatorEducation[] _endLevelButtonIndicatorEducation;
    [SerializeField] private GarageUI _garageUI;

    public JoystickIndicatorEducation[] JoystickIndicators => _joystickIndicators;
    public AddFuelIndicatorEducation[] AddFuelIndicators => _addFuelIndicators;
    public EndLevelButtonIndicatorEducation[] EndLevelButtonIndicatorEducation => _endLevelButtonIndicatorEducation;

    public GarageUI GarageUI => _garageUI;
}
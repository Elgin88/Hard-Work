using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private JoystickIndicatorEducation[] _joystickIndicators;
    [SerializeField] private AddFuelIndicatorEducation[] _addFuelIndicators;
    [SerializeField] private GarageUI _garageUI;

    private GameRequireComponents _gameRequireComponents;
    public GameRequireComponents GameRequireComponents => _gameRequireComponents;

    public JoystickIndicatorEducation[] JoystickIndicators => _joystickIndicators;
    public AddFuelIndicatorEducation[] AddFuelIndicators => _addFuelIndicators;

    public GarageUI GarageUI => _garageUI;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
    }
}
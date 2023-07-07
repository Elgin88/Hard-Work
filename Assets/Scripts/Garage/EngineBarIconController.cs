using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineBarIconController : MonoBehaviour
{
    [SerializeField] private EngineBarIconColorSetter _colorSetter1;
    [SerializeField] private EngineBarIconColorSetter _colorSetter2;
    [SerializeField] private EngineBarIconColorSetter _colorSetter3;
    [SerializeField] private EngineBarIconFlash _flasher1;
    [SerializeField] private EngineBarIconFlash _flasher2;
    [SerializeField] private EngineBarIconFlash _flasher3;
    [SerializeField] private float _maxDeltaScaleX;
    [SerializeField] private float _maxDeltaScaleY;
    [SerializeField] private float _maxDeltaScaleZ;
    [SerializeField] private float _duration;

    private PlayerPowerController _powerController;

    public float MaxScaleX => _maxDeltaScaleX;
    public float MaxScaleY => _maxDeltaScaleY;
    public float MaxScaleZ => _maxDeltaScaleZ;
    public float Duration => _duration;    

    private void OnEnable()
    {
        _powerController = FindObjectOfType<PlayerPowerController>();
        _powerController.IsEngineUpgrade += OnUpgradeEngine;
    }

    private void OnDisable()
    {
        _powerController.IsEngineUpgrade -= OnUpgradeEngine;
    }

    private void OnUpgradeEngine(int level, bool isMaxLevel)
    {
        if (level == 1)
        {
            _colorSetter1.StartChangeColor();
            _flasher1.StartFlash();
        }
        else if (level == 2)
        {
            _colorSetter2.StartChangeColor();
            _flasher2.StartFlash();
        }
        else if (level == 3)
        {
            _colorSetter3.StartChangeColor();
            _flasher3.StartFlash();
        }
    }
}

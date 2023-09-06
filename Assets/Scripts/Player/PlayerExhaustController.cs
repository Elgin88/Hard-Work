using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExhaustController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _exhaust;
    [SerializeField] private PlayerFuelController _fuelController;

    private void OnEnable()
    {
        _fuelController.IsFuelChanged += OnChangedFuelValue ;
    }

    private void OnDisable()
    {
        _fuelController.IsFuelChanged -= OnChangedFuelValue;
    }

    private void OnChangedFuelValue(float current, float max)
    {
        if (current == 0)
        {
            _exhaust.Stop();
        }
    }
}

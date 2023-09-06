using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorsEducation : MonoBehaviour
{
    [SerializeField] private BarrelIndicatorEducation[] _barrelIndicatorsEducation;
    [SerializeField] private CollectorIndicatorEducation[] _collectorIndicatorsEducation;
    [SerializeField] private GarageIndicatorEducation[] _garageIndicatorsEducation;

    public BarrelIndicatorEducation[] BarrelIndicators => _barrelIndicatorsEducation;
    public CollectorIndicatorEducation[] CollectorIndicatorsEducation => _collectorIndicatorsEducation;
    public GarageIndicatorEducation[] GarageIndicatorsEducation => _garageIndicatorsEducation;
}
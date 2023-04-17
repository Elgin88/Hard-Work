using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerFuelController))]
[RequireComponent(typeof(PlayerPowerController))]

public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private int _deltaMaxFuel;
    [SerializeField] private int _deltaMaxLines;
    [SerializeField] private float _deltaPower;

    private PlayerPowerController _powerController;
    private PlayerFuelController _fuelController;
    private LineOfPointsCreater _lineOfPointsCreater;
    private Garage _fuelCost;

    private void Start()
    {
        _fuelController = GetComponent<PlayerFuelController>();
        _powerController = GetComponent<PlayerPowerController>();

        _lineOfPointsCreater = FindObjectOfType<LineOfPointsCreater>();
    }

    public void TryBuyFuel()
    {
        _fuelController.TryBuyFuel();
    }

    public void TryBuyTank()
    {
        _fuelController.TryBuyTank(_deltaMaxFuel);
    }

    public void TryAddPlace()
    {
        _lineOfPointsCreater.TryAddPlace(_deltaMaxLines);
    }

    public void TryAddPower()
    {
        _powerController.TryAddPower(_deltaPower);
    }
}
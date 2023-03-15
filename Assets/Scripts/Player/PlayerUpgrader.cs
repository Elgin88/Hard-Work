using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerFuelController))]

public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private int _deltaMaxFuel;
    [SerializeField] private int _deltaMaxPlace;
    [SerializeField] private float _deltaPower;

    private PlayerPowerController _powerController;
    private PlayerFuelController _fuelController;
    private LineOfPointsCreater _lineOfPointsCreater;
    private Garage _fuelCost;

    private void Start()
    {
        if (_deltaMaxFuel == 0|| _deltaMaxPlace == 0 || _deltaPower == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

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
        _lineOfPointsCreater.TryAddPlace(_deltaMaxPlace);
    }

    public void TryAddPower()
    {
        _powerController.TryAddPower(_deltaPower);
    }
}
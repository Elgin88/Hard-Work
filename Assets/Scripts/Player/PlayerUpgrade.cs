using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerFuelController))]

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] private int deltaMaxFuel;

    private PlayerFuelController _fuelController;
    private Garage _fuelCost;

    private void Start()
    {
        if (deltaMaxFuel == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        _fuelController = GetComponent<PlayerFuelController>();
    }

    public void TryBuyFuel()
    {
        _fuelController.TryBuyFuel();
    }

    internal void AddTank()
    {
        _fuelController.TryBuyTank(deltaMaxFuel);
    }
}

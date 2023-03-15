using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private string _fuelLabel;
    [SerializeField] private string _tankLabel;
    [SerializeField] private string _placeLabel;
    [SerializeField] private string _powerLabel;

    [SerializeField] private int _fuelCost;
    [SerializeField] private int _tankCost;
    [SerializeField] private int _placeCost;
    [SerializeField] private int _powerCost;

    public string FuelLabel => _fuelLabel;
    public string TankLabel => _tankLabel;
    public string PlaceLabel => _placeLabel;
    public string PowerLabel => _powerLabel;

    public int FuelCoust => _fuelCost;
    public int TankCost => _tankCost;
    public int PlaceCost => _placeCost;
    public int PowerCost => _powerCost;

    private void Start()
    {
        if (_fuelLabel == null || _tankLabel == null ||
            _placeLabel == null || _powerLabel == null ||

            _fuelCost == 0 || _tankCost == 0 ||
            _placeCost == 0 || _powerCost == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }
}
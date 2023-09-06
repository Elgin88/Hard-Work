using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private string _fuelLabelRU;
    [SerializeField] private string _tankLabelRU;
    [SerializeField] private string _placeLabelRU;
    [SerializeField] private string _powerLabelRU;

    [SerializeField] private int _fuelCost;
    [SerializeField] private int _tankCost;
    [SerializeField] private int _placeCost;
    [SerializeField] private int _powerCost;

    public string FuelLabel => _fuelLabelRU;
    public string TankLabel => _tankLabelRU;
    public string PlaceLabel => _placeLabelRU;
    public string PowerLabel => _powerLabelRU;

    public int FuelCoust => _fuelCost;
    public int TankCost => _tankCost;
    public int PlaceCost => _placeCost;
    public int PowerCost => _powerCost;

    private void Start()
    {
        if (_fuelLabelRU == null || _tankLabelRU == null ||
            _placeLabelRU == null || _powerLabelRU == null ||

            _fuelCost == 0 || _tankCost == 0 ||
            _placeCost == 0 || _powerCost == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }
}
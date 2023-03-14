using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private string _fuelLabel;
    [SerializeField] private string _tankLabel;
    [SerializeField] private int _fuelCost;
    [SerializeField] private int _tankCost;    

    public string FuelLabel => _fuelLabel;
    public string TankLabel => _tankLabel;
    public int FuelCoust => _fuelCost;
    public int TankCost => _tankCost;
}

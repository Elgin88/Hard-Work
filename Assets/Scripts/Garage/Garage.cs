using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    [SerializeField] private string _fuelLabel;
    [SerializeField] private int _fuelCost;

    public string FuelLabel => _fuelLabel;
    public int FuelCoust => _fuelCost;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChooserMedals))]

public class GameRequireComponents : MonoBehaviour
{
    [SerializeField] private GarageUI _garageUI;
    [SerializeField] private ChooserMedals _chooserMedals;

    public ChooserMedals ChooserMedals => _chooserMedals;
    public GarageUI GarageUI => _garageUI;
}

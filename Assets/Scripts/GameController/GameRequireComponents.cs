using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChooserMedals))]

public class GameRequireComponents : MonoBehaviour
{
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private EndLevelButton _endLevelButton;
    [SerializeField] private GarageUI _garageUI;

    private ChooserMedals _chooserMedals;    

    public EndLevelPanel EndLevelPanel => _endLevelPanel;
    public EndLevelButton EndLevelButton => _endLevelButton;
    public ChooserMedals ChooserMedals => _chooserMedals;

    public GarageUI GarageUI => _garageUI;

    private void Start()
    {
        _chooserMedals = GetComponent<ChooserMedals>();
    }
}

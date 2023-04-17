using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameRequireComponents : MonoBehaviour
{
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private DestroyerPoint _destroyerPoint;
    [SerializeField] private GarageParkingArea _garageParkingArea;
    [SerializeField] private GarageUI _garageUI;
    [SerializeField] private EnderLevel _enderLevel;
    [SerializeField] private Garage _garage;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUpgrader _playerUpgrader;
    [SerializeField] private LineOfPoints _lineOfPoints;
    [SerializeField] private Unloader _unloader;
    [SerializeField] private MaxFuelBar _maxFuelBar;
    [SerializeField] private MiddleFuelBar _middleFuelBar;
    [SerializeField] private MinFuelBar _minFuelBar;
    [SerializeField] private ReloadButton _reloadButton;
    [SerializeField] private EndLevelButton _endLevelButton;
    [SerializeField] private MaxMedal _maxMedal;
    [SerializeField] private MiddleMedal _middleMedal;
    [SerializeField] private MinMedal _minMedal;

    public EndLevelPanel EndLevelPanel => _endLevelPanel;
    public DestroyerPoint DestroyerPoint => _destroyerPoint;
    public GarageParkingArea GarageParkingArea => _garageParkingArea;
    public GarageUI GarageUI => _garageUI;
    public EnderLevel EnderLevel => _enderLevel;
    public Garage Garage => _garage;
    public Player Player => _player;
    public PlayerUpgrader PlayerUpgrade => _playerUpgrader;
    public LineOfPoints LineOfPoints => _lineOfPoints;
    public Unloader Unloader => _unloader;
    public MaxFuelBar MaxFuelBar => _maxFuelBar;
    public MiddleFuelBar MiddleFuelBar => _middleFuelBar;
    public MinFuelBar MinFuelBar => _minFuelBar;
    public ReloadButton ReloadButton => _reloadButton;
    public EndLevelButton EndLevelButton => _endLevelButton;
    public MaxMedal MaxMedal => _maxMedal;
    public MiddleMedal MiddleMedal => _middleMedal;
    public MinMedal MinMedal => _minMedal;
}

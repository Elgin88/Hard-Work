using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRequireComponents : MonoBehaviour
{

    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private DestroyerPoint _destroyerPoint;
    [SerializeField] private GarageParkingArea _garageParkingArea;
    [SerializeField] private GarageUI _garageUI;
    [SerializeField] private GameRequireComponents _enderLevel;
    [SerializeField] private Garage _garage;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUpgrader _playerUpgrader;

    public EndLevelPanel EndLevelPanel => _endLevelPanel;
    public DestroyerPoint DestroyerPoint => _destroyerPoint;
    public GarageParkingArea GarageParkingArea => _garageParkingArea;
    public GarageUI GarageUI => _garageUI;
    public GameRequireComponents EnderLevel => _enderLevel;
    public Garage Garage => _garage;
    public Player Player => _player;
    public PlayerUpgrader PlayerUpgrade => _playerUpgrader;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Player))]

public class PlayerPowerController : MonoBehaviour
{
    [SerializeField] private int _maxLevelEngine;

    private PlayerSpeedSetter _playerSpeedSetter;
    private Player _player;
    private Garage _garage;
    private int _engineLevel;
    private bool _isMaxLevel = false;

    public bool IsMaxLevel => _isMaxLevel;

    public event UnityAction<int, bool> IsEngineUpgrade;

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _player = GetComponent<Player>();

        _garage = FindObjectOfType<Garage>();
    }

    public void TryAddPower(float deltaPower)
    {
        if (_player.Money > _garage.PowerCost & _engineLevel < 3)
        {
            _playerSpeedSetter.ChangeDeltaPushSpeed(deltaPower);
            _player.RemoveMoney(_garage.PowerCost);
            _engineLevel++;

            if (_engineLevel == _maxLevelEngine)
                _isMaxLevel = true;

            IsEngineUpgrade?.Invoke(_engineLevel, _isMaxLevel);
        }
    }    
}

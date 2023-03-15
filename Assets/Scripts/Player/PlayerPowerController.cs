using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Player))]

public class PlayerPowerController : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private Player _player;
    private Garage _garage;

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _player = GetComponent<Player>();

        _garage = FindObjectOfType<Garage>();
    }

    public void TryAddPower(float deltaPower)
    {
        if (_player.Money > _garage.PowerCost)
        {
            _playerSpeedSetter.ChangeDeltaPushSpeed(deltaPower);
            _player.RemoveMoney(_garage.PowerCost);
        }
    }
}

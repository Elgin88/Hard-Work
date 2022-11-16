using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerController))]

public class PlayerCurrentSpeedSetter : MonoBehaviour
{
    private PlayerController _playerController;
    private Coroutine _changeSpeedWork = null; 
    private Player _player;

    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();        
        _player = GetComponent<Player>();

        StartCoroutineChangeSpeed();
    }

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            if (_playerController.IsJoystickWork)
            {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _player.MaxSpeed, _player.ChangeUpSpeed * Time.deltaTime);
            }
            else
            {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _player.MinSpeed, _player.ChangeDownSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private void StartCoroutineChangeSpeed()
    {
        if (_changeSpeedWork == null)
        {
            _changeSpeedWork = StartCoroutine(ChangeSpeed());
        }
    }

    private void StopCoroutineChangeSpeed()
    {
        if (_changeSpeedWork != null)
        {
            StopCoroutine(_changeSpeedWork);
            _changeSpeedWork = null;
        }
    }
}

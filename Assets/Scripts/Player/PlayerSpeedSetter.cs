using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerController))]

public class PlayerSpeedSetter : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _deltaUpSpeed;
    [SerializeField] private float _deltaDownSpeed;

    private PlayerController _playerController;
    private Coroutine _changeSpeedWork = null;
    private float _currentSpeed;

    public float DeltaDownSpeed => _deltaDownSpeed;
    public float CurrentSpeed => _currentSpeed;
    public float DeltaUpSpeed => _deltaUpSpeed;
    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        StartCoroutineChangeSpeed();
    }

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            if (_playerController.IsJoystickWork)
            {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _maxSpeed, _deltaUpSpeed * Time.deltaTime);
            }
            else
            {
                _currentSpeed = Mathf.MoveTowards(_currentSpeed, _minSpeed, _deltaDownSpeed * Time.deltaTime);
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

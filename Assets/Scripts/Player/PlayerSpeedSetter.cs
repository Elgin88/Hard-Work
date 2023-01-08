using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerSpeedSetter : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _deltaUpSpeed;
    [SerializeField] private float _deltaDownSpeed;
    [SerializeField] private float _pushChangeSpeed;
    [SerializeField] private float _delayPush;

    private Player _player;
    private PlayerMover _playerController;
    private Coroutine _changeSpeedWork = null;

    private float _timeAftetLastPush;
    private float _currentSpeed;
    

    public float DeltaDownSpeed => _deltaDownSpeed;
    public float CurrentSpeed => _currentSpeed;
    public float DeltaUpSpeed => _deltaUpSpeed;
    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerController = GetComponent<PlayerMover>();

        _player.IsPushed += IsPushedPlayer;
        StartCoroutineChangeSpeed();
    }

    private void Update()
    {
        _timeAftetLastPush += Time.deltaTime;
    }

    private void OnDisable()
    {
        _player.IsPushed -= IsPushedPlayer;
    }

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            if (_playerController.IsJoystickTurn == true)
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

    private void IsPushedPlayer()
    {
        if (_delayPush < _timeAftetLastPush)
        {
            _currentSpeed -= _pushChangeSpeed;

            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }
            
            _timeAftetLastPush = 0;
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

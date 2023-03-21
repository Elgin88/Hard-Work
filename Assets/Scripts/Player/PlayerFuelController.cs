using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerFuelController : MonoBehaviour
{
    [SerializeField] private float _maxFuel = 100;
    [SerializeField] private float _deltaFuel = 3;
    [SerializeField] private Garage _garage;

    private float _currentFuel;
    private bool _isFuelLoss;
    private Coroutine _burnFuel;
    private PlayerSpeedSetter _speedSetter;
    private Player _player;

    public bool IsFuelLoss => _isFuelLoss;
    public float MaxFuel => _maxFuel;

    public event UnityAction <float, float> IsFuelChanged;

    private void Start()
    {
        if (_maxFuel == 0|| _deltaFuel == 0 || _garage == null )
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        if (_speedSetter == null)
        {
            _speedSetter = FindObjectOfType<PlayerSpeedSetter>();
        }

        _player = GetComponent<Player>();

        _currentFuel = _maxFuel;

        StartBurnFuel();        
    }

    private IEnumerator LessFuel()
    {
        while (true)
        {
            _currentFuel -= _speedSetter.CurrentSpeed * _deltaFuel * Time.deltaTime;
            IsFuelChanged.Invoke(_currentFuel, _maxFuel);

            if (_currentFuel < 0)
            {
                _isFuelLoss = true;
            }
            else
            {
                _isFuelLoss = false;
            }

            yield return null;
        }
    }

    private void StartBurnFuel()
    {
        if (_burnFuel == null)
        {
            _burnFuel = StartCoroutine(LessFuel());
        }
    }

    private void StopBurnFuel()
    {
        if (_burnFuel != null)
        {
            StopCoroutine(_burnFuel);
            _burnFuel = null;
        }
    }

    public void TryBuyFuel()
    {
        if (_player.Money > _garage.FuelCoust)
        {
            _currentFuel = _maxFuel;
            IsFuelChanged?.Invoke(_currentFuel, _maxFuel);
            _player.RemoveMoney(_garage.FuelCoust);           
        }
    }

    internal void TryBuyTank(int addVolumeTank)
    {
        if (_player.Money > _garage.TankCost)
        {
            _player.RemoveMoney(_garage.TankCost);
            _maxFuel += addVolumeTank;
            IsFuelChanged?.Invoke(_currentFuel, _maxFuel);
        }
    }
}

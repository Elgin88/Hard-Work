using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerController;
    private Inventory _inventory;
    private Unloader _unloader;
    private float _startPositionY;
    private int _money;
    private bool _isUpload;
    private bool _isUnload;    

    public Inventory Inventory => _inventory;
    public Unloader Unloader => _unloader;
    public int Money => _money;
    public bool IsUpload => _isUpload;
    public bool IsUnload => _isUnload;
    public event UnityAction IsPushed;
    public event UnityAction <int> IsMoneyChanged;

    private void Start()
    {
        _playerController = GetComponent<PlayerMover>();
        _inventory = GetComponentInChildren<Inventory>();
        _unloader = GetComponentInChildren<Unloader>();

        _startPositionY = transform.position.y;
    }

    public void SlowDown()
    {
        IsPushed.Invoke();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _startPositionY, transform.position.z);
    }

    public Quaternion GetCurrentDirection()
    {
        return _playerController.CurrentPlayerDirection;
    }

    public void AddMoney(int money)
    {
        _money += money;
        IsMoneyChanged?.Invoke(_money);
    }

    public void RemoveMoney(int money)
    {
        _money -= money;
        IsMoneyChanged?.Invoke(_money);
    }

    public void SetStatusUpload(bool status)
    {
        _isUpload = status;
    }

    public void SetStatusUnload(bool status)
    {
        _isUnload = status;
    }
}

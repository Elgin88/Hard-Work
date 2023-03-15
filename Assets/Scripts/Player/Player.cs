using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerLoadController))]

public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private Inventory _inventory;
    private Unloader _unloader;
    private PlayerLoadController _loadController;
    private float _startPositionY;
    private int _money;
    private bool _isUpload;
    private bool _isUnload;    

    public Inventory Inventory => _inventory;
    public Unloader Unloader => _unloader;
    public PlayerLoadController LoadController => _loadController;
    public int Money => _money;
    public bool IsUpload => _isUpload;
    public bool IsUnload => _isUnload;

    public event UnityAction IsPushed;
    public event UnityAction <int> IsMoneyChanged;    

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _loadController = GetComponent<PlayerLoadController>();

        _inventory = GetComponentInChildren<Inventory>();
        _unloader = GetComponentInChildren<Unloader>();
    }

    public void SlowDown()
    {
        IsPushed.Invoke();
    }

    public Quaternion GetCurrentDirection()
    {
        return _mover.CurrentPlayerDirection;
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
}

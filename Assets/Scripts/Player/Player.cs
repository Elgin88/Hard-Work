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
    private float _startPositionY;
    private int _money;

    private bool _isUploading = false;
    private bool _isUnloading = false;    

    public Inventory Inventory => _inventory;
    public bool IsUploading => _isUploading;
    public bool IsUnloading => _isUnloading;
    public int Money => _money;

    public event UnityAction IsPushed;

    private void Start()
    {
        _playerController = GetComponent<PlayerMover>();
        _inventory = GetComponentInChildren<Inventory>();

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

    public void SetIsUnloadingFalse()
    {
        _isUnloading = false;
    }

    public void SetIsUnloadingTrue()
    {
        _isUnloading = true;
    }

    public void SetIsUploadingFalse()
    {
        _isUploading = false;
    }

    public void SetIsUploadingTrue()
    {
        _isUploading = true;
    }

    public void AddMoney(int blockPrice)
    {
        _money += blockPrice;
    }
}

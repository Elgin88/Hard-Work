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

    private bool _isUpload = false;

    public Inventory Inventory => _inventory;

    public bool IsUploading => _isUpload;

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

    public void SetIsUploadingFalse()
    {
        _isUpload = false;
    }

    public void SetIsUploadingTrue()
    {
        _isUpload = true;
    }
}

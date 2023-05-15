using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BlockFixer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(BlockMoverToPlayer))]
[RequireComponent(typeof(BlockMoverToCollector))]

public class Block : MonoBehaviour
{
    private int _cost = 1;

    private BlockMoverToCollector _blockMoverToCollector;
    private BlockMoverToPlayer _moverBlock;
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private Player _player;
    private Point _point;
    private bool _playerIsUnload;

    public BlockMoverToCollector BlockMoverToCollector => _blockMoverToCollector;
    public Player Player => _player;
    public Point Point => _point;
    public int Cost => _cost;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _moverBlock = GetComponent<BlockMoverToPlayer>();
        _blockMoverToCollector = GetComponent<BlockMoverToCollector>();        
    }

    private void BlocksUnloaded(bool isUnload)
    {
        _playerIsUnload = isUnload;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            KinematicOff();
            GravityOn();           

            _player = destroyer.Player;
            _player.SlowDown();

            if (_playerIsUnload != true & _player.LoadController.IsUnload == false)
            {
                _point = _player.Inventory.TryTakePoint();

                if (_point != null)
                {
                    KinematicOn();
                    ColliderOff();
                    GravityOff();

                    _point.InitBlock(this);
                    _moverBlock.StartFlight();
                }
            }
        }
    }

    public void WakeUp()
    {
        _rigidbody.WakeUp();
    }

    public void GravityOn()
    {
        _rigidbody.useGravity = true;
    }

    public void GravityOff()
    {
        _rigidbody.useGravity = false;
    }

    public void ColliderOn()
    {
        _boxCollider.enabled = true;
    }

    public void ColliderOff()
    {
        _boxCollider.enabled = false;
    }

    public void KinematicOn()
    {
        _rigidbody.isKinematic = true;        
    }

    public void KinematicOff()
    {
        _rigidbody.isKinematic = false;
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3 (x, y, z);
    }

    public void SetQuaternion(Quaternion currentRotation)
    {
        transform.rotation = currentRotation;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
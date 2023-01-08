using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken = 8;

    private BoxCollider _boxCollider;
    private BlockMover _moverBlock;
    private Inventory _inventory;
    private Rigidbody _rigidbody;
    private Player _player;
    private Point _point;

    public Point PointOnPlayer => _point;
    public Player Player => _player;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _moverBlock = GetComponent<BlockMover>();        
        _rigidbody = GetComponent<Rigidbody>();        
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _player = destroyer.Player;
            _inventory = _player.Inventory;

            KinematicOff();
            GravityOn();

            _point = _inventory.TryTakePoint();
            _player.Push();

            if (_point != null)
            {
                KinematicOn();
                ColliderOff();
                GravityOff();

                _moverBlock.StartCoroutineFlight();
            }
        }
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
}
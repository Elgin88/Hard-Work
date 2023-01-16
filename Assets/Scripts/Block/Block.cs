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
    [SerializeField] private float _delayForTaken = 8;

    private BlockMoverToCollector _blockMoverToCollector;
    private BlockMoverToPlayer _moverBlock;
    private BoxCollider _boxCollider;
    private Inventory _inventory;
    private Rigidbody _rigidbody;
    private Player _player;
    private Block _block;
    private Point _point;

    public BlockMoverToCollector BlockMoverToCollector => _blockMoverToCollector;
    public Point PointOnPlayer => _point;
    public Player Player => _player;

    private void Start()
    {
        _block = GetComponent<Block>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _moverBlock = GetComponent<BlockMoverToPlayer>();
        _blockMoverToCollector = GetComponent<BlockMoverToCollector>();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            KinematicOff();
            GravityOn();

            _player = destroyer.Player;
            _player.SlowDown();
            _inventory = _player.Inventory;
            _blockMoverToCollector.InitPlayer(_player);            

            _point = _inventory.TryTakePoint();
            _point.InitBlock(this);

            if (_point != null)
            {
                KinematicOn();
                ColliderOff();
                GravityOff();

                _point.InitBlock(_block);
                _moverBlock.StartCoroutineFlight();
            }
        }
    }

    public Point GetPointOnPlayer()
    {
        return _point;
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

    public void MadePointIsNull()
    {
        _point = null;
    }
}
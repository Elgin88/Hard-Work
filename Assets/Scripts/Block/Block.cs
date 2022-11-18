using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    private BlockPoint _blockPoint;
    private BlockMover _moverBlock;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _topFlightPointOfBlock;
    private Player _player;

    public Player Player => _player;

    public BlockPoint BlockPoint => _blockPoint;

    private void Start()
    {
        _moverBlock = GetComponent<BlockMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _collider.enabled = false;
            _rigidbody.useGravity = false;

            _moverBlock.StartCoroutineFlight();
        }
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position.Set(x, y, z);
    }
}
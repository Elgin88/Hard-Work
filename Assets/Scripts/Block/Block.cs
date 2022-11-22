using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken;

    private BlockPointFinder _blockPointFinder;
    private BlockPoint _blockPoint;
    private BlockMover _moverBlock;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Player _player;
    

    public Player Player => _player;

    public BlockPoint BlockPoint => _blockPoint;

    private void Start()
    {
        _blockPointFinder = FindObjectOfType<BlockPointFinder>().GetComponent<BlockPointFinder>();
        _moverBlock = GetComponent<BlockMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (Time.realtimeSinceStartup > _delayForTaken)
                _blockPoint = _blockPointFinder.TryChooseBlockPoin();

            if (Time.realtimeSinceStartup > _delayForTaken & _blockPoint != null)
            {
                _collider.enabled = false;
                _rigidbody.useGravity = false;

               _moverBlock.StartCoroutineFlight(_blockPoint);
            }            
        }
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3 (x, y, z);
    }

    public void SetQuaternion(Transform playerTransform)
    {
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken;

    private BlockMover _moverBlock;
    private Inventory _inventory;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _curentDirection;
    private Player _player;    
    private Point _point;

    public Player Player => _player;
    public Point BlockPoint => _point;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponentInChildren<Inventory>();
        _moverBlock = GetComponent<BlockMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true ;

            if (Time.realtimeSinceStartup > _delayForTaken)
            {
                _point = _inventory.TryTakePoin();
            }

            if (Time.realtimeSinceStartup > _delayForTaken & _point != null)
            {
                _collider.enabled = false;
                _rigidbody.useGravity = false;

                _point.TakePoint();
               _moverBlock.StartCoroutineFlight(_point);
            }            
        }
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3 (x, y, z);
    }

    public void SetQuaternion(Rigidbody rigidbodyPlayer)
    {
        if (rigidbodyPlayer.velocity != Vector3.zero)
        {
            _curentDirection = rigidbodyPlayer.velocity;
        }

        transform.rotation = Quaternion.LookRotation(_curentDirection);
    }
}
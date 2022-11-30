using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken;

    private BlockMover _moverBlock;
    private Inventory _inventory;
    private Rigidbody _rigidbody;
    private Player _player;    
    private Point _point;

    public Player Player => _player;
    public Point BlockPoint => _point;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponentInChildren<Inventory>();
        _moverBlock = GetComponent<BlockMover>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            KinematicControll(false);
            UseGravityControll(true);

            if (Time.realtimeSinceStartup > _delayForTaken)
            {
                _point = _inventory.TryTakePoin();
            }

            if (Time.realtimeSinceStartup > _delayForTaken & _point != null)
            {
                KinematicControll(false);
                UseGravityControll(false);

                _point.TakePoint();
                _moverBlock.StartCoroutineFlight(_point);
            }            
        }
    }

    public void KinematicControll(bool status)
    {
        _rigidbody.isKinematic = status;
    }

    public void UseGravityControll(bool status)
    {
        _rigidbody.useGravity = status;
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3 (x, y, z);
    }

    public void SetQuaternion(Vector3 currentRotation)
    {
        transform.rotation = Quaternion.LookRotation(currentRotation);
    }
}
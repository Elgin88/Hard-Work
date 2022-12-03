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
    private Point _pointOnPlayer;

    public Player Player => _player;
    public Point BlockPoint => _pointOnPlayer;

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
            KinematicControll(true);

            _pointOnPlayer = _inventory.TryTakePoin();

            Debug.Log(_pointOnPlayer);

            if (_pointOnPlayer != null)
            {
                KinematicControll(false);
                _moverBlock.StartCoroutineFlight(_pointOnPlayer);
            }            
        }
    }

    public void KinematicControll(bool status)
    {
        _rigidbody.isKinematic = status;
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
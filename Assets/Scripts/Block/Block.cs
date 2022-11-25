using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken;

    private PointFinderInLine _rowPointFinder;
    private Point _point;
    private BlockMover _moverBlock;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Player _player;    

    public Player Player => _player;
    public Point BlockPoint => _point;

    private void Start()
    {
        _rowPointFinder = FindObjectOfType<PointFinderInLine>().GetComponent<PointFinderInLine>();
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
                _point = _rowPointFinder.TryTakeRandomPoin();

            if (Time.realtimeSinceStartup > _delayForTaken & _point != null)
            {
                _collider.enabled = false;
                _rigidbody.useGravity = false;

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
        transform.rotation = Quaternion.LookRotation(rigidbodyPlayer.velocity);
    }
}
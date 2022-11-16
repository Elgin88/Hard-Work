using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MoverBlock))]

public class Block : MonoBehaviour
{
    private MoverBlock _moveBlock;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _topFlightPointOfBlock;
    private PointForBlock _pointForBlockOnPlayer;
    private Player _player;

    public PointForBlock PointForBlockOnPlayer => _pointForBlockOnPlayer;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _moveBlock = GetComponent<MoverBlock>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _collider.enabled = false;
            _rigidbody.useGravity = false;

            Vector3 transformPositionWorld = transform.TransformDirection(transform.position);

            float topFlightPointOfBlockX = (_player.transform.position.x + transformPositionWorld.x) / 2;
            float topFlightPointOfBlockY = (_player.transform.position.y + _player.BlockTossHeight);
            float topFlightPointOfBlockZ = (_player.transform.position.z + transformPositionWorld.z) / 2;

            _topFlightPointOfBlock = new Vector3 (topFlightPointOfBlockX, topFlightPointOfBlockY,topFlightPointOfBlockZ);

            _pointForBlockOnPlayer = _player.GetPointForBlock();
            _moveBlock.SetTopFlightPoint(_topFlightPointOfBlock);
            _moveBlock.StartCoroutineFlight();
        }
    }
    
}

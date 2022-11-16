using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MoverBlock))]
[RequireComponent(typeof(Collider))]

public class Block : MonoBehaviour
{
    private PointForBlock _pointForBlockOnPlayer;
    private MoverBlock _moverBlock;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _topFlightPointOfBlock;
    private Player _player;

    public PointForBlock PointForBlockOnPlayer => _pointForBlockOnPlayer;

    private void Start()
    {
        _moverBlock = GetComponent<MoverBlock>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
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
            _moverBlock.SetTopFlightPoint(_topFlightPointOfBlock);
            _moverBlock.StartCoroutineFlight();
        }
    }    
}
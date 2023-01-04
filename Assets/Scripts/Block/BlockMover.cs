using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]
[RequireComponent(typeof(BlockFixer))]

public class BlockMover : MonoBehaviour
{
    [SerializeField] private float _flightSpeed = 10;
    [SerializeField] private float _tossHeight = 3;

    private BlockFixer _blockFixer;
    private Rigidbody _rigidbody;
    private Coroutine _flightWork = null;
    private Vector3 _topFlightPoint;    
    private Block _block;
    private bool _isReachTopPoint = false;    

    private void Start()
    {
        _blockFixer = GetComponent<BlockFixer>();
        _rigidbody = GetComponent<Rigidbody>();
        _block = GetComponent<Block>();   
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _rigidbody.centerOfMass = new Vector3(0,0,0);

            if (_isReachTopPoint == false)
            {
                _topFlightPoint = new Vector3((_block.PointOnPlayer.transform.position.x + transform.position.x) / 2, _block.PointOnPlayer.transform.position.y + _tossHeight, (_block.PointOnPlayer.transform.position.z + transform.position.z) / 2);

                transform.position = Vector3.MoveTowards(transform.position, _topFlightPoint, _flightSpeed * Time.deltaTime);

                if (transform.position == _topFlightPoint)
                {
                    _isReachTopPoint = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _block.PointOnPlayer.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _block.PointOnPlayer.transform.position)
                {
                    StopCoroutineMove();
                    _blockFixer.StartCoroutineFixBlock();
                }
            }

            yield return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StartCoroutineFlight()
    {
        if (_flightWork == null)
        {
            _flightWork = StartCoroutine(Move());
        }
    }

    public void StopCoroutineMove()
    {
        if (_flightWork != null)
        {
            StopCoroutine(_flightWork);
            _flightWork = null;
        }
    }
}
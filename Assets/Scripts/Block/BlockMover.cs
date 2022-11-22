using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]
[RequireComponent(typeof(BlockFixer))]

public class BlockMover : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;
    [SerializeField] private float _tossHeight;
    

    private BlockFixer _blockFixer;
    private BlockPoint _blockPoint;
    private Coroutine _flightWork = null;
    private Vector3 _topFlightPoint;
    private Block _block;
    private bool _isReachTopPoint = false;

    public BlockPoint BlockPoint => _blockPoint;

    private void Start()
    {
        _blockFixer = GetComponent<BlockFixer>();
        _block = GetComponent<Block>();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_isReachTopPoint == false)
            {
                _topFlightPoint = new Vector3((_blockPoint.transform.position.x + transform.position.x) / 2, _blockPoint.transform.position.y + _tossHeight, (_blockPoint.transform.position.z + transform.position.z) / 2);

                transform.position = Vector3.MoveTowards(transform.position, _topFlightPoint, _flightSpeed * Time.deltaTime);

                if (transform.position == _topFlightPoint)
                    _isReachTopPoint = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _blockPoint.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _blockPoint.transform.position)
                {
                    StopCoroutineMove();
                    _blockFixer.StartCoroutineFixBlock(_block, _blockPoint);
                }
            }

            yield return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StartCoroutineFlight(BlockPoint blockPoint)
    {
        _blockPoint = blockPoint;

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
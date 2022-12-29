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
    private Coroutine _flightWork = null;
    private Vector3 _topFlightPoint;
    private Point _pointOnPlayer;
    private Block _block;
    private bool _isReachTopPoint = false;

    public Point PointOnPlayer => _pointOnPlayer;

    private void Start()
    {
        _blockFixer = GetComponent<BlockFixer>();
        _block = GetComponent<Block>();

        if (_flightSpeed == 0)
            Debug.Log("In BlocMover no _flightSpeed");

        if (_flightSpeed == 0)
            Debug.Log("In BlocMover no _tossHeight");
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (_isReachTopPoint == false)
            {
                _topFlightPoint = new Vector3((_pointOnPlayer.transform.position.x + transform.position.x) / 2, _pointOnPlayer.transform.position.y + _tossHeight, (_pointOnPlayer.transform.position.z + transform.position.z) / 2);

                transform.position = Vector3.MoveTowards(transform.position, _topFlightPoint, _flightSpeed * Time.deltaTime);

                if (transform.position == _topFlightPoint)
                    _isReachTopPoint = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _pointOnPlayer.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _pointOnPlayer.transform.position)
                {
                    StopCoroutineMove();
                    _blockFixer.StartCoroutineFixBlock(_block, _pointOnPlayer);
                }
            }

            yield return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StartCoroutineFlight(Point blockPoint)
    {
        _pointOnPlayer = blockPoint;

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
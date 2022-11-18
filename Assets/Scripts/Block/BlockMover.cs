using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;
    [SerializeField] private float _tossHeight;

    private BlockPointFinder _finderBlockPoint;
    private BlockPoint _blockPoint;

    private Coroutine _flightWork = null;
    private Vector3 _topFlightPoint;

    private bool _isReachTopPoint = false;

    private void Start()
    {
        _finderBlockPoint = FindObjectOfType<Player>().GetComponent<BlockPointFinder>();
    }

    private IEnumerator Flight()
    {
        _blockPoint = _finderBlockPoint.GetBlockPoin();

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
                    StopCoroutineFlight();
            }

            yield return null;
        }
    }

    public void StartCoroutineFlight()
    {
        if (_flightWork == null)
        {
            _flightWork = StartCoroutine(Flight());
        }
    }

    public void StopCoroutineFlight()
    {
        if (_flightWork != null)
        {
            StopCoroutine(_flightWork);
            _flightWork = null;
        }
    }
}
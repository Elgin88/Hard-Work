using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBlock : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;

    private Player _player;

    private Coroutine _moveWork = null;
    private Vector3 _topFlightPointOfBlock;
    private bool _isReachTopPoint = false;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private IEnumerator Flight()
    {
        while (true)
        {
            if (_isReachTopPoint == false)
            {
                transform.position = Vector3.MoveTowards
                    (transform.position, _topFlightPointOfBlock, _flightSpeed * Time.deltaTime);

                if (transform.position == _topFlightPointOfBlock)
                    _isReachTopPoint = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards
                    (transform.position, GetPointOnPlayer(), _flightSpeed * Time.deltaTime);

                if (transform.position == GetPointOnPlayer())
                    StopCoroutineMove();
            }

            yield return null;
        }
    }

    private Vector3 GetPointOnPlayer()
    {
        return _player.GetPointForBlock().transform.position;
    }

    public void SetTopFlightPoint(Vector3 topPoint)
    {
        _topFlightPointOfBlock = topPoint;
    }

    public void StartCoroutineMove()
    {
        if (_moveWork == null)
        {
            _moveWork = StartCoroutine(Flight());
        }
    }

    public void StopCoroutineMove()
    {
        if (_moveWork != null)
        {
            StopCoroutine(_moveWork);
            _moveWork = null;
        }
    }
}

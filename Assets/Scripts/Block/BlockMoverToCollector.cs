using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoverToCollector : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _deltaYToTopPoint;

    private Coroutine _moveCoroutine;
    private Vector3 _collectionPoint;
    private Vector3 _startPosition;
    private Vector3 _topPoint;
    private Player _player;
    private bool _isReached = false;

    private void Start()
    {
        if (_speed == 0 || _deltaYToTopPoint == 0)
            Debug.Log("BlockMoverToCollector no SerializeField" + gameObject.name);

        _collectionPoint = FindObjectOfType<CollectionPoint>().transform.position;
        _player = GetComponent<Block>().Player;
        _startPosition = transform.position;
    }

    private IEnumerator MoveToCollector()
    {
        while (true)
        {
            if (_isReached == false)
            {
                GetTopPointPosition();
                transform.position = Vector3.MoveTowards(transform.position, _topPoint, _speed * Time.deltaTime);

                if (transform.position == _topPoint)
                {
                    _isReached = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _collectionPoint, _speed * Time.deltaTime);
            }

            yield return null;
        }
    }

    private void GetTopPointPosition()
    {
        _topPoint = new Vector3((_player.transform.position.x - _collectionPoint.x)/2 , _startPosition.y + _deltaYToTopPoint, (_player.transform.position.z - _collectionPoint.z) / 2);
    }

    public void StartCoroutineMove()
    {
        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToCollector());
        }

    }

    public void StorCoroutine()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }
}

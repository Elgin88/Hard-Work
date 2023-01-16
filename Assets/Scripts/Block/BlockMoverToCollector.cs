using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoverToCollector : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tossHight;

    private Block _block;
    private BlockFixer _blockFixer;
    private Coroutine _moveCoroutine = null;
    private Player _player;

    private Vector3 _collectionPoint;
    private Vector3 _startPosition;
    private Vector3 _topPoint;

    private bool _isReachedTopPoint = false;

    private void Start()
    {
        if (_speed == 0 || _tossHight == 0)
            Debug.Log("BlockMoverToCollector no SerializeField" + gameObject.name);

        _blockFixer = GetComponent<BlockFixer>();
        _block = GetComponent<Block>();

        _startPosition = transform.position;
    }

    public void InitPlayer(Player player)
    {
        _player = player;
    }

    private IEnumerator MoveToCollector()
    {
        _blockFixer.StopCoroutineFixBlock();
        _block.MadePointIsNull();
        GetTopPointPosition();

        while (true)
        {
            if (_isReachedTopPoint == false)
            {

                transform.position = Vector3.MoveTowards(transform.position, _topPoint, _speed * Time.deltaTime);

                if (transform.position == _topPoint)
                {
                    _isReachedTopPoint = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _collectionPoint, _speed * Time.deltaTime);
            }

            if (transform.position == _collectionPoint)
            {
                StorCoroutineMove();
            }

            yield return null;
        }
    }

    private void GetTopPointPosition()
    {
        _topPoint = new Vector3((_player.transform.position.x + _collectionPoint.x)/2 , _startPosition.y + _tossHight, (_player.transform.position.z + _collectionPoint.z) / 2);
    }

    public void StartCoroutineMove(Vector3 collectionPoint)
    {
        _collectionPoint = collectionPoint;

        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToCollector());
        }
    }

    public void StorCoroutineMove()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }
}

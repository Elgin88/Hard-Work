using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockFixer))]
[RequireComponent(typeof(Block))]

public class BlockMoverToCollector : MonoBehaviour
{
    private float _flightSpeed = 10;
    private float _tossHight = 3;
    private float _deltaPointPosition = 0.2f;
    private float _deltaHight = 0.2f;

    private BlockFixer _blockFixer;
    private Coroutine _move;
    private Block _block;
    private Unloader _unloader;
    private CalculatorBlocks _calculatorBlocks;
    private Vector3 _collectionPoint;
    private Vector3 _topPoint;
    private bool _isReachedTopPoint = false;

    private void Start()
    {
        if (_flightSpeed == 0 || _tossHight == 0 || _deltaPointPosition == 0 || _deltaHight == 0)
            Debug.Log("No SerializeField in " + this.name);
    }

    private IEnumerator MoveToCollector()
    {
        if (_calculatorBlocks == null)
        {
            _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
            _blockFixer = GetComponent<BlockFixer>();
            _block = GetComponent<Block>();
        }

        _blockFixer.StopCoroutineFixBlock();

        _collectionPoint = new Vector3(_collectionPoint.x + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition), _collectionPoint.y, _collectionPoint.z + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition));

        SetTopPointPosition();

        _block.Point.RemoveBlock();

        while (true)
        {
            if (_isReachedTopPoint == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _topPoint, _flightSpeed * Time.deltaTime);

                if (transform.position == _topPoint)
                {
                    _isReachedTopPoint = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _collectionPoint, _flightSpeed * Time.deltaTime);
            }

            _block.Player.IsMoveToCollector(true);

            if (transform.position.y - _collectionPoint.y < 0.1)
            {
                _block.Player.AddMoney(_block.Cost);
                _calculatorBlocks.AddUnloadBloks();
                _block.Player.Inventory.InitEventBlockIsChanged();

                StopCoroutineMoveToCollector();
                _block.Player.IsMoveToCollector(false);

                _block.Destroy();
            }

            yield return null;
        }
    }

    private void SetTopPointPosition()
    {
        _topPoint = new Vector3((_block.Player.transform.position.x + _collectionPoint.x)/2 , transform.position.y + _tossHight + Random.Range(-1* _deltaHight, _deltaHight), (_block.Player.transform.position.z + _collectionPoint.z) / 2);
    }

    public void StartCoroutineMoveToCollector(Vector3 collectionPoint)
    {
        _collectionPoint = collectionPoint;

        if (_move == null)
        {
            _move = StartCoroutine(MoveToCollector());
        }
    }

    public void StopCoroutineMoveToCollector()
    {
        if (_move != null)
        {
            StopCoroutine(_move);
            _move = null;
        }
    }
}
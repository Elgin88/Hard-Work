using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoverToCollector : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tossHight;
    [SerializeField] private float _deltaPointPosition;
    [SerializeField] private float _deltaHight;

    private BlockFixer _blockFixer;
    private Coroutine _moveCoroutine;
    private Player _player;
    private Block _block;
    private Unloader _unloader;

    private Vector3 _collectionPoint;
    private Vector3 _topPoint;

    private bool _isReachedTopPoint = false;

    private void Start()
    {
        if (_speed == 0 || _tossHight == 0 || _deltaPointPosition == 0 || _deltaHight == 0)
            Debug.Log("No SerializeField in " + this.name);

        _blockFixer = GetComponent<BlockFixer>();
        _block = GetComponent<Block>();
    }

    private IEnumerator MoveToCollector()
    {
        _blockFixer.StopCoroutineFixBlock();

        _collectionPoint = new Vector3(_collectionPoint.x + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition), _collectionPoint.y, _collectionPoint.z + Random.Range(-1 * _deltaPointPosition, _deltaPointPosition));

        SetTopPointPosition();

        _block.Point.RemoveBlock();

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

            if (transform.position.y - _collectionPoint.y < 0.1)
            {
                _block.Player.AddMoney(_block.Cost);
                _block.Player.Unloader.ActiveEventBlockUnloded();

                StopCoroutineMoveToCollector();
            }

            yield return null;
        }
    }

    public void Init (Player player)
    {
        _player = player;
    }

    private void SetTopPointPosition()
    {
        _topPoint = new Vector3((_block.Player.transform.position.x + _collectionPoint.x)/2 , transform.position.y + _tossHight + Random.Range(-1* _deltaHight, _deltaHight), (_block.Player.transform.position.z + _collectionPoint.z) / 2);
    }

    public void StartCoroutineMoveToCollector(Vector3 collectionPoint)
    {
        _collectionPoint = collectionPoint;

        if (_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToCollector());
        }
    }

    public void StopCoroutineMoveToCollector()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }
}

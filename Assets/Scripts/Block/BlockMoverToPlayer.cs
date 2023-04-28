using System.Collections;
using UnityEngine;

public class BlockMoverToPlayer : MonoBehaviour
{
    private float _flightSpeed = 10;
    private float _tossHeight = 3;

    private BlockFixer _blockFixer;
    private Rigidbody _rigidbody;
    private Coroutine _flightWork;
    private Vector3 _topPointPosition;
    private Vector3 _startBlockPosition;
    private Block _block;
    private bool _isReachTop;
    private BlockMoverToCollector _blockMoverToCollector;

    private void OnEnable()
    {
        _blockFixer = GetComponent<BlockFixer>();        
        _rigidbody = GetComponent<Rigidbody>();        
        _block = GetComponent<Block>();
        _blockMoverToCollector = GetComponent<BlockMoverToCollector>();
    }

    private IEnumerator Flight()
    {
        _isReachTop = false;
        _startBlockPosition = transform.position;

        while (true)
        {
            _block.Player.LoadController.SetUploadStatus(true);

            if (_block.Point != null)
            {
                _topPointPosition = new Vector3((_block.Point.transform.position.x + _startBlockPosition.x) / 2, _block.Point.transform.position.y + _tossHeight, (_block.Point.transform.position.z + _startBlockPosition.z) / 2);
            }

            if (_isReachTop == false & _block.Point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _topPointPosition, _flightSpeed * Time.deltaTime);

                if (transform.position == _topPointPosition)
                {
                    _isReachTop = true;
                }
            }
            else if(_block.Point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _block.Point.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _block.Point.transform.position)
                {
                    StopCoroutineMove();

                    _blockFixer.StartCoroutineFixBlock();                    
                    _block.Player.Inventory.InitEventBlockIsChanged();
                }                               
            }

            if (_block.Point == null)
            {
                StopCoroutineMove();
                _blockMoverToCollector.StartMoveToCollector(_block.Player.CollectionPOintPosition);
            }

            yield return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void StartFlight()
    {
        if (_flightWork == null)
        {
            _flightWork = StartCoroutine(Flight());
        }
    }

    public void StopCoroutineMove()
    {
        if (_flightWork != null)
        {
            StopCoroutine(_flightWork);

            _flightWork = null;
        }

        _block.Player.LoadController.SetUploadStatus(false);
    }
}
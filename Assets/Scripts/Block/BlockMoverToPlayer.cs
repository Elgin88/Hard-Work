using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BlockFixer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Block))]

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

    private void Start()
    {
        if (_flightSpeed == 0 || _tossHeight == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        _blockFixer = GetComponent<BlockFixer>();        
        _rigidbody = GetComponent<Rigidbody>();        
        _block = GetComponent<Block>();   
    }

    private IEnumerator Flight()
    {
        _isReachTop = false;
        _startBlockPosition = transform.position;

        while (true)
        {
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

                _block.Player.IsMoveToPlayer(true);
            }
            else if(_block.Point != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _block.Point.transform.position, _flightSpeed * Time.deltaTime);

                if (transform.position == _block.Point.transform.position)
                {
                    StopCoroutineMove();

                    _blockFixer.StartCoroutineFixBlock();                    
                    _block.Player.Inventory.InitEventBlockIsChanged();
                    _block.Player.IsMoveToPlayer(false);                    
                }                               
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
    }
}
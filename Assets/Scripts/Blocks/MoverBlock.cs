using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]

public class MoverBlock : MonoBehaviour
{
    [SerializeField] private float _flightSpeed;

    private Player _player;

    private Coroutine _flightWork = null;
    private Vector3 _topFlightPointOfBlock;
    private Block _block;
    private bool _isReachTopPoint = false;

    private void Start()
    {
        _block = GetComponent<Block>();
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
                    (transform.position, GetPositionPointForBlock(_block.PointForBlockOnPlayer), _flightSpeed * Time.deltaTime);

                if (transform.position == _block.PointForBlockOnPlayer.transform.position)
                    StopCoroutineFlight();
            }

            yield return null;
        }
    }

    private Vector3 GetPositionPointForBlock(PointForBlock pointForBlock)
    {
        return _player.GetPositionPointForBlock(pointForBlock);
    }

    public void SetTopFlightPoint(Vector3 topFlightPointOfBlock)
    {
        _topFlightPointOfBlock = topFlightPointOfBlock;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockPoints))]

public class BlockPointFinder : MonoBehaviour
{
    private BlockPoints _blockPoints;
    private BlockPointCreater _blockPointCreater;

    private void Start()
    {
        _blockPointCreater = GetComponent<BlockPointCreater>();
        _blockPoints = GetComponent<BlockPoints>();
        _blockPoints.GetCountPoints();
    }

    public BlockPoint TryTakeBlockPoin()
    {
        bool isWork = true;

        while (isWork)
        {
            int index = Random.Range(0, _blockPoints.GetCountPoints());           

            if (_blockPoints.CheckPointOnTaken(index) == false)
            {
                _blockPoints.TakePlace(index);
                _blockPoints.IncreaseNumberTakenPointInRow();
                _blockPointCreater.CreateBlockPoint(_blockPoints.GetBlockPoint(index));

                return _blockPoints.GetBlockPoint(index);
            }            

            if (_blockPoints.CheckFullNessRow())
                isWork = false;
        }

        return null;
    }
}
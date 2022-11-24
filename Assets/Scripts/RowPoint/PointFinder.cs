using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RowPoints))]

public class PointFinder : MonoBehaviour
{
    private RowPoints _blockPoints;
    private RowPointCreater _blockPointCreater;

    private void Start()
    {
        _blockPointCreater = GetComponent<RowPointCreater>();
        _blockPoints = GetComponent<RowPoints>();
        _blockPoints.GetCountPoints();
    }

    public Point TryTakeBlockPoin()
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
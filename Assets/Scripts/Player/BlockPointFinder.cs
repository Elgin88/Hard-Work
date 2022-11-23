using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockPoints))]

public class BlockPointFinder : MonoBehaviour
{
    private BlockPoints _blockPoints;

    private void Start()
    {
        _blockPoints = GetComponent<BlockPoints>();
    }

    public BlockPoint TryChooseBlockPoin()
    {
        bool isWork = true;

        while (isWork)
        {
            int index = Random.Range(0, _blockPoints.GetCountPoints());           

            if (_blockPoints.CheckPointOnTaken(index) == false)
            {
                _blockPoints.TakePlace(index);
                _blockPoints.IncreaseNumberTakenPointInRow();

                return _blockPoints.GetBlockPoint(index);
            }

            if (_blockPoints.CheckFullNessRow())
                isWork = false;
        }

        return null;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Block _block;
    private bool _isTaken = false;
    private BlockMoverToCollector _blockMoverToCollector;

    public void Take()
    {
        _isTaken = true;
        _blockMoverToCollector = _block.gameObject.GetComponent<BlockMoverToCollector>();
    }

    public bool CheckIsTaken()
    {
        if (_isTaken == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Upload()
    {
        _blockMoverToCollector.StartCoroutineMove();
    }

    public void SetBlock(Block block)
    {
        _block = block;
    }
}

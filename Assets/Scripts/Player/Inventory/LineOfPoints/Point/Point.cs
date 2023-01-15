using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Block _block;
    private bool _isTaken = false;

    public Block Block => _block;

    public void Take()
    {
        _isTaken = true;
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

    public void InitBlock(Block block)
    {
        _block = block;
    }

    public Block GetBlock()
    {
        return _block;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Block _block;

    public Block Block => _block;

    public bool CheckIsTaken()
    {
        if (_block == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Point Take()
    {
        return this;
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

    public void RemoveBlock()
    {
        _block = null;
    }
}

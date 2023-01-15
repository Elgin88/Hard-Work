using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfPointsCreater))]

public class Inventory : MonoBehaviour
{
    private bool _isFull = false;

    private LineOfPointsCreater _lineOfPointsCreater;
    private List <LineOfPoints> _lines;
    private Block _lastBlockInInventory;

    public Block LastBlockInInventory => _lastBlockInInventory;

    private void Start()
    {
        _lines = new List<LineOfPoints>();

        LineOfPoints[] tempLines = GetComponentsInChildren<LineOfPoints>();

        foreach (LineOfPoints tempLine in tempLines)
        {
            _lines.Add(tempLine);
        }

        _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
    }

    public void CreateLine()
    {
        _lineOfPointsCreater.CreateLine();
    }

    public void AddLine(LineOfPoints line)
    {
        _lines.Add(line);
    }

    public int GetCountOfLines()
    {
        return _lines.Count;
    }

    public Point TryTakePoint()
    {
        if (CheckIsFull() == true)
        {
            CreateLine();
        }

        if (CheckIsFull() == false)
        {
            foreach (LineOfPoints line in _lines)
            {
                Point point = line.TakePoint();

                if (point != null)
                {
                    return point;
                }
            }
        }

        return null;
    }

    public bool CheckIsFull()
    {
        foreach (LineOfPoints line in _lines)
        {
            if (line.CheckIsFull() == false)
            {
                _isFull = false;
                return _isFull;
            }
        }

        _isFull = true;
        return _isFull;
    }

    public Block GetLastBlock()
    {
        Debug.Log("Попытка получения блока в " + this.name);

        _lastBlockInInventory = _lines[_lines.Count - 1].GetLastBlock();

        return _lastBlockInInventory;
    }
}
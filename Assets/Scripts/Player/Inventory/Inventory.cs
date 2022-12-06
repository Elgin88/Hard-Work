using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfPointsCreater))]

public class Inventory : MonoBehaviour
{
    private bool _isFull = false;

    private List<LineOfPoints> _lines = new List<LineOfPoints>();
    private LineOfPointsCreater _lineOfPointsCreater;

    private void Start()
    {
        LineOfPoints[] tempLines = GetComponentsInChildren<LineOfPoints>();

        foreach (LineOfPoints tempLine in tempLines)
        {
            _lines.Add(tempLine);
        }

        _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
    }

    public void AddLine(LineOfPoints line)
    {
        _lines.Add(line);
    }

    public int GetCountOfLines()
    {
        return _lines.Count;
    }

    public Point TryTakePoin()
    {
        if (CheckIsFull() == true && _lines.Count < _lineOfPointsCreater.MaxNumberLines)        
        {
            _lineOfPointsCreater.TryCreateLine();
        }
        else
        {
            foreach (LineOfPoints line in _lines)
            {
                Point point = line.TryTakePoint();

                if (point!=null)
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
}
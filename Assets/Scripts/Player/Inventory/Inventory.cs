using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfPoints))]

public class Inventory : MonoBehaviour
{
    private List<LineOfPoints> _lines = new List<LineOfPoints>();

    private LineOfPointsCreater _lineCreater;
    private bool _isFull;

    private void Start()
    {
        LineOfPoints []tempLine = GetComponentsInChildren<LineOfPoints>();
        _lineCreater = GetComponent<LineOfPointsCreater>();

        foreach (var line in tempLine)
        {
            _lines.Add(line);
        }
    }

    public LineOfPoints GetLineOfPoints(int index)
    {
        return _lines[index];
    }

    public int GetCountLines()
    {
        return _lines.Count;
    }

    public Point TryTakePoint(int index)
    {
        foreach (var line in _lines)
        {
            if (line.CheckLineIsFull() == false)
            {
                return line.TakePoint();
            }
        }

        return null;
    }

    public void AddLine(LineOfPoints lineOfPoints)
    {
        _lines.Add(lineOfPoints);
    }

    public bool CheckIsInventoryFull()
    {
        int numberIsTakenLines = 0;

        foreach (LineOfPoints line in _lines)
        {
            if (line.CheckLineIsFull() == true)
            {
                numberIsTakenLines++;
            }
        }

        if (numberIsTakenLines == _lines.Count)
        {
            _isFull = true;
        }
        else
        {
            _isFull = false;
        }

        return _isFull;
    }

    public Point TryTakePoin()
    {
        CheckIsInventoryFull();

        if (_isFull == true)
        {
            _lineCreater.TryCreateLine();
        }

        if (_isFull == false)
        {
            foreach (var line in _lines)
            {
                line.TakePoint();
            }
        }

        return null;
    }

    public LineOfPoints GetLastLineInList()
    {
        return _lines[_lines.Count - 1];
    }
}
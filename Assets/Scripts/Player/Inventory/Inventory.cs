using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<LineOfPoints> _lines = new List<LineOfPoints>();

    private void Start()
    {
        LineOfPoints []tempLineOfPoints = GetComponentsInChildren<LineOfPoints>();

        foreach (var line in tempLineOfPoints)
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
                return line.TryTakePoint();
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
        bool isFull = false;

        foreach (LineOfPoints line in _lines)
        {
            if (line.CheckLineIsFull() == true)
            {
                numberIsTakenLines++;
            }

            if (numberIsTakenLines == _lines.Count)
            {
                isFull = true;                
            }
            else
            {
                isFull = false;
            }
        }

        return isFull;
    }

    public Point TryTakePoin()
    {
        foreach (var line in _lines)
        {
            if (CheckIsInventoryFull() == false)
            {
                if (line.CheckLineIsFull() == false)
                {
                    return line.TryTakePoint();
                }                
            }
        }

        return null;
    }

    public LineOfPoints GetLastLineInList()
    {
        return _lines[_lines.Count - 1];
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<LineOfPoints> _lines = new List<LineOfPoints>();
    private bool _isInventoryFull = false;

    public bool IsFullInventory => _isInventoryFull;

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
            if (line.IsFull == false)
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

    public bool IsTaken(int index)
    {
        return _lines[index].IsFull;
    }

    public bool CheckInventoruIsFull()
    {
        int numberIsTakenLines = 0;

        foreach (LineOfPoints line in _lines)
        {
            if (line.IsFull == true)
            {
                numberIsTakenLines++;
            }

            if (numberIsTakenLines == _lines.Count)
            {
                _isInventoryFull = true;
            }
            else
            {
                _isInventoryFull = false;
            }
        }

        return _isInventoryFull;
    }

    public Point TryTakePoin()
    {
        foreach (var line in _lines)
        {
            if (CheckInventoruIsFull() == false)
            {
                if (line.IsFull == false)
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
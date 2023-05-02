using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineOfPointsCreater))]
[RequireComponent(typeof(Unloader))]

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<LineOfPoints> _lines;

    private bool _isFull = false;
    private LineOfPointsCreater _lineOfPointsCreater;

    public int GetNumberLines => _lines.Count;

    public event UnityAction <int,int> IsChangedNumberBlocks;

    private void OnEnable()
    {
        _lineOfPointsCreater = GetComponent<LineOfPointsCreater>();
    }

    public void TryCreateLine()
    {
        _lineOfPointsCreater.TryCreateLine();
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
            TryCreateLine();
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

    public Block TryGetLastAddBlock()
    {
        return _lines[_lines.Count - 1].GetLastAddBlockInLine();  
    }

    public void RemoveTopLine()
    {
        GameObject lineToDestroy = _lines[_lines.Count - 1].gameObject;

        _lines.Remove(_lines[_lines.Count - 1]);
        Destroy(lineToDestroy);
    }

    public int GetNumberBloksInTopLine()
    {
        return _lines[_lines.Count - 1].GetNumberOfBlocks();
    }

    public int GetCurrentNumberOfBlocks()
    {
        int currentNumberOfBlocks = 0;

        foreach (LineOfPoints line in _lines)
        {
            currentNumberOfBlocks += line.GetNumberOfBlocks();
        }

        return currentNumberOfBlocks;
    }

    public int GetMaxNumberOfBlocks()
    {
        return _lineOfPointsCreater.MaxNumberOfLines * _lines[0].GetNumberOfPoints();
    }

    public void InitEventBlockIsChanged()
    {
        IsChangedNumberBlocks?.Invoke(GetCurrentNumberOfBlocks(), GetMaxNumberOfBlocks());
    }
}
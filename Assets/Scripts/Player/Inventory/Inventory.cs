using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<LineOfPoints> _lines;

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

    public bool IsTaken(int index)
    {
        return _lines[index].IsTaken;
    }

    public Point TryTakePoint(int index)
    {
        if (_lines[index].IsTaken == false)
        {
            return _lines[index].TryTakePoint();
        }

        return null;
    }

    public void AddLine(LineOfPoints lineOfPoints)
    {
        _lines.Add(lineOfPoints);
    }
}
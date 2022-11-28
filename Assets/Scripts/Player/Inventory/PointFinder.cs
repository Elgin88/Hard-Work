using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFinder : MonoBehaviour
{
    private List<LineOfPoints> _lines = new List<LineOfPoints>();
    private LineOfPoints[] _tempLines;

    private void Start()
    {
        _tempLines = GetComponentsInChildren<LineOfPoints>();

        foreach (var tempLine in _tempLines)
        {
            _lines.Add(tempLine);
        }
    }

    public Point TryTakePoint()
    {
        foreach (var line in _lines)
        {
            if (line.IsTaken == false)
            {
                return line.TryTakePoint();
            }            
        }

        return null;        
    }
}
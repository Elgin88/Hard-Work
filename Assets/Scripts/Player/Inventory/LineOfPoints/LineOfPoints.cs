using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointFinderInLine))]

public class LineOfPoints : MonoBehaviour
{
    private bool _isTaken;
    private PointFinderInLine _pointFinderInLine;
    private int _numberTakenPoint = 0;

    public bool IsTaken => _isTaken;
    public int NumberTakenPoint => _numberTakenPoint;

    private void Start()
    {
        _pointFinderInLine = GetComponent<PointFinderInLine>();
    }

    public void TakeAllPoints()
    {
        _isTaken = true;
    }

    public void FreePointInLine()
    {
        _isTaken = false;
    }

    public void IncreaceNumberTakenPoint()
    {
        _numberTakenPoint++;
    }

    public Point TryTakePoint()
    {
        if (_isTaken == false)
        {
            return _pointFinderInLine.TryTakeRandomPoin();
        }

        return null;        
    }
}

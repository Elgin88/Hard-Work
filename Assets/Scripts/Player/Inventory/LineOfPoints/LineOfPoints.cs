using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointFinderInLine))]

public class LineOfPoints : MonoBehaviour
{
    private Point [] _points;

    private PointFinderInLine _pointFinderInLine;
    private Coroutine _checkIsTakenWork = null;
    private bool _isFull = false;
    private int _numberTakenPoint = 0;

    public bool IsFull => _isFull;
    public int NumberTakenPoint => _numberTakenPoint;

    private void Start()
    {
        _pointFinderInLine = GetComponent<PointFinderInLine>();
        _points = GetComponentsInChildren<Point>();
    }

    public void TakenAllPoints()
    {
        _isFull = true;
    }

    public void FreePointInLine()
    {
        _isFull = false;
    }

    public void IncreaceNumberTakenPoint()
    {
        _numberTakenPoint++;
    }

    public Point TryTakePoint()
    {
        if (CheckLineIsFull() == false)
        {
            return _pointFinderInLine.TakeRandomPoin();
        }

        return null;        
    }

    public void MoveUp(float deltaY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + deltaY, transform.position.z);
    }

    private bool CheckLineIsFull()
    {
        int numberOfTakenPoints = 0;

        foreach (var point in _points)
        {
            _isFull = false;

            if (point.IsTaken == true)
            {
                numberOfTakenPoints++;
            }
        }

        if (_points.Length == numberOfTakenPoints)
        {
            _isFull = true;
        }
        else
        {
            _isFull = false;
        }

        return _isFull;           
    }
}

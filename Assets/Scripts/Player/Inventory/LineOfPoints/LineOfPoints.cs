using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointFinderInLine))]
[RequireComponent(typeof(Point))]

public class LineOfPoints : MonoBehaviour
{
    private Point [] _points;

    private PointFinderInLine _pointFinderInLine;
    private Coroutine _checkIsTakenWork = null;    
    private int _numberTakenPoint = 0;
    
    public int NumberTakenPoint => _numberTakenPoint;

    private void Start()
    {
        _pointFinderInLine = GetComponent<PointFinderInLine>();
        _points = GetComponentsInChildren<Point>();
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

    public bool CheckLineIsFull()
    {
        int numberOfTakenPoints = 0;
        bool isFull = false;

        foreach (Point point in _points)
        {
            if (point.IsTaken == true)
            {
                numberOfTakenPoints++;
            }
        }

        if (_points.Length == numberOfTakenPoints)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }

        return isFull;           
    }
}

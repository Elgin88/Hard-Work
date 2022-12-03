using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointFinderInLine))]

public class LineOfPoints : MonoBehaviour
{
    private Point [] _points;

    private PointFinderInLine _pointFinderInLine;
    private bool _isFull;
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

    public Point TakePoint()
    {
        return _pointFinderInLine.TakeRandomPoin();              
    }

    public void MoveUp(float deltaY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + deltaY, transform.position.z);
    }

    public bool CheckLineIsFull()
    {
        int numberOfTakenPoints = 0;        

        foreach (Point point in _points)
        {
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
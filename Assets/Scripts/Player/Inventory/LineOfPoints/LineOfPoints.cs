using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PointFinderInLine))]

public class LineOfPoints : MonoBehaviour
{
    private Point [] _points;

    private  Coroutine _checkIsTakenWork;
    private bool _isTaken = false;
    private PointFinderInLine _pointFinderInLine;
    private int _numberTakenPoint = 0;

    public bool IsTaken => _isTaken;
    public int NumberTakenPoint => _numberTakenPoint;

    private void Start()
    {
        _pointFinderInLine = GetComponent<PointFinderInLine>();

        _checkIsTakenWork = StartCoroutine(CheckIsTaken());

        _points = GetComponentsInChildren<Point>();
    }

    public void TakenAllPoints()
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

    private IEnumerator CheckIsTaken()
    {
        while (true)
        {
            foreach (var point in _points)
            {
                if (point.IsTaken == false)
                {
                    _isTaken = false;
                }
            }

            yield return null;
        }    
    }

}

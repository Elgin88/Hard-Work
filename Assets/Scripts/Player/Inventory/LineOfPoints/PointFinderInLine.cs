using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfPoints))]

public class PointFinderInLine : MonoBehaviour
{
    
    private LineOfPoints _lineOfPoins;
    private Point[] _points;

    private void Start()
    {
        _lineOfPoins = GetComponent<LineOfPoints>();
        _points = GetComponentsInChildren<Point>();
    }

    public Point TryTakeRandomPoin()
    {
        if (_lineOfPoins.IsTaken == false)
        {
            bool isWork = true;

            while (isWork)
            {
                int index = Random.Range(0, _points.Length);

                if (_points[index].IsTaken == false)
                {
                    _lineOfPoins.IncreaceNumberTakenPoint();

                    if (_lineOfPoins.NumberTakenPoint == _points.Length)
                    {
                        _lineOfPoins.TakenAllPoints();
                    }

                    return _points[index];
                }                
            }
        }

        return null;
    }
}

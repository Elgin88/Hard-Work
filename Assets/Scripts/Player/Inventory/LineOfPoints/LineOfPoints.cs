using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfPoints : MonoBehaviour
{
    private Point[] _points;
    private bool _isFull = false;

    private void Start()
    {
        _points = GetComponentsInChildren<Point>();
    }

    internal Point TryTakePoint()
    {
        if (CheckIsFull() == false & _points != null)
        {
            foreach (Point point in _points)
            {
                if (point.CheckIsTaken() == false)
                {
                    point.Take();
                    return point;
                }
            }
        }

        return null;
    }

    public bool CheckIsFull()
    {
        if (_points !=null)
        {
            foreach (Point point in _points)
            {
                if (point.CheckIsTaken() == false)
                {
                    _isFull = false;
                    return _isFull;
                }
            }

            _isFull = true;
        }
        
        return _isFull;
    }

    internal void MoveUp(float deltaBetweenBlocks)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + deltaBetweenBlocks, transform.position.z);
    }
}
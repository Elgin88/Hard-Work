using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfPoints : MonoBehaviour
{
    private List<Point> _points;
    private bool _isFull = false;

    private void OnEnable()
    {
        _points = new List<Point>();

        Point[] tempPoints = GetComponentsInChildren<Point>();

        foreach (Point tempPoint in tempPoints)
        {
            _points.Add(tempPoint);
        }
    }

    public Point TakePoint()
    {
        foreach (Point point in _points)
        {
            if (point.CheckIsTaken() == false)
            {
                point.Take();
                return point;
            }
        }

        return null;
    }

    public bool CheckIsFull()
    {
        foreach (Point point in _points)
        {
            if (point.Block == false)
            {
                _isFull = false;
                return _isFull;
            }
        }
        
        _isFull = true;
        
        return _isFull;
    }

    public void MoveUp(float deltaBetweenBlocks)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + deltaBetweenBlocks, transform.position.z);
    }

    public Block GetLastAddBlock()
    {
        Block lastAddBlock = null;

        foreach (Point point in _points)
        {
            if (point.Block)
            {
                lastAddBlock = point.Block;
            }
        }

        return lastAddBlock;        
    }

    public void RemoveLine()
    {
        Destroy(gameObject);
    }

    public int GetNumberBlocks()
    {
        int numberOfBlocks = 0;

        foreach (Point point in _points)
        {
            if (point.Block != null)
            {
                numberOfBlocks++;
            }
        }

        return numberOfBlocks;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowPoints : MonoBehaviour
{
    private List<Point> _points = new List<Point>();
    private Point[] _tempPoints;
    private int _numberTakenPointInRow = 0;

    private void Start()
    {
        _tempPoints = GetComponentsInChildren<Point>();

        for (int i = 0; i < _tempPoints.Length; i++)        
            _points.Add(_tempPoints[i]);

        _tempPoints = null;
    }

    public int GetCountPoints()
    {
        int count;
        count = _points.Count;

        return count;
    }

    public bool CheckPointOnTaken(int index)
    {
        return _points[index].IsTaken;
    }

    public void TakePlace(int index)
    {
        _points[index].TakePlace();
    }

    public void IncreaseNumberTakenPointInRow()
    {
        _numberTakenPointInRow++;
    }

    public Point GetBlockPoint(int index)
    {
        return _points[index];
    }

    public bool CheckFullNessRow()
    {
        if (_numberTakenPointInRow == _points.Count)
            return true;        

        return false;
    }

    public void AddPoint(Point blockPoint)
    {
        _points.Add(blockPoint);
    }
}

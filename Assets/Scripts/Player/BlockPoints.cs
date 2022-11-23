using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPoints : MonoBehaviour
{
    private List<BlockPoint> _points = new List<BlockPoint>();
    private BlockPoint[] _tempPoints;
    private int _numberTakenPointInRow = 0;

    private void Start()
    {
        _tempPoints = GetComponentsInChildren<BlockPoint>();

        for (int i = 0; i < _tempPoints.Length; i++)        
            _points.Add(_tempPoints[i]);
    }

    public int GetCountPoints()
    {
        return _points.Count;
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

    public BlockPoint GetBlockPoint(int index)
    {
        return _points[index];
    }

    public bool CheckFullNessRow()
    {
        if (_numberTakenPointInRow == _points.Count)
            return true;        

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class BlockPointFinder : MonoBehaviour
{
    private BlockPoint [] _tempPoints;
    private List<BlockPoint> _points;
    private int _numberTakenPoint = 0;

    private void Start()
    {
        _tempPoints = FindObjectOfType<BlockPoints>().GetComponentsInChildren<BlockPoint>();
        _points = new List<BlockPoint>();

        foreach (var point in _tempPoints)
        {
            _points.Add(point);            
        }
    }

    public BlockPoint TryChooseBlockPoin()
    {
        bool isWork = true;

        while (isWork)
        {
            int index = Random.Range(0, _points.Count);            

            if (_points[index].IsTaken == false)
            {
                _points[index].TakePlace();
                _numberTakenPoint++;

                return _points[index];
            }

            if (_points.Count == _numberTakenPoint)
                isWork = false;
        }

        return null;
    }
}
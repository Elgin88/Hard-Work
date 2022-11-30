using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFinderInLine : MonoBehaviour
{
    private Point[] _points;

    private void Start()
    {
        _points = GetComponentsInChildren<Point>();
    }

    public Point TakeRandomPoin()
    {
        bool isWork = true;

        while (isWork)
        {
            int index = Random.Range(0, _points.Length);

            if (_points[index].IsTaken == false)
            {
                isWork = false;
                return _points[index];
            }
        }

        return null;
    }
}

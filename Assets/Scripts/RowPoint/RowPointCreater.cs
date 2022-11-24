using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RowPoints))]

public class RowPointCreater : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private Point _template;

    private Vector3 _blockPointPosition;
    private RowPoints _blockPoints;

    private void Start()
    {
        _blockPoints = GetComponent<RowPoints>();
    }

    public void CreateBlockPoint(Point parentBlockPoint)
    {
        Point blockPoint = Instantiate(_template, parentBlockPoint.transform);        

        _blockPoints.AddPoint(blockPoint);
    }
}

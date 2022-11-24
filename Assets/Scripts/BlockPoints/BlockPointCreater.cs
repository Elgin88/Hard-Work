using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockPoints))]

public class BlockPointCreater : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private BlockPoint _template;

    private Vector3 _blockPointPosition;
    private BlockPoints _blockPoints;

    private void Start()
    {
        _blockPoints = GetComponent<BlockPoints>();
    }

    public void CreateBlockPoint(BlockPoint parentBlockPoint)
    {
        BlockPoint blockPoint = Instantiate(_template, parentBlockPoint.transform);        

        _blockPoints.AddPoint(blockPoint);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class FinderPointForBlock : MonoBehaviour
{
    private PointForBlock [] _points;

    private void Start()
    {
        _points = FindObjectOfType<PointsForBlocks>().GetComponentsInChildren<PointForBlock>();
    }

    public PointForBlock GetCurrentPoint()
    {
        return _points[Random.Range(0, _points.Length)];
    }
}
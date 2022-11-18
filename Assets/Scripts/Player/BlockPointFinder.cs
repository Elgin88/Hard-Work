using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class BlockPointFinder : MonoBehaviour
{
    private BlockPoint [] _points;

    private void Start()
    {
        _points = FindObjectOfType<BlockPoints>().GetComponentsInChildren<BlockPoint>();        
    }

    public BlockPoint GetBlockPoin()
    {
        return _points[Random.Range(0, _points.Length)];
    }
}
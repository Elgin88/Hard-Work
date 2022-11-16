using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockLocationFinder))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _changeUpSpeed;
    [SerializeField] private float _changeDownSpeed;
    [SerializeField] private float _blockTossHeight;

    private BlockLocationFinder _pointsForBlock;

    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;
    public float ChangeUpSpeed => _changeUpSpeed;
    public float ChangeDownSpeed => _changeDownSpeed;
    public float BlockTossHeight => _blockTossHeight;

    private void Start()
    {
        _pointsForBlock = GetComponent<BlockLocationFinder>();
    }

    public PointForBlock GetPointForBlock()
    {
        return _pointsForBlock.GetCurrentPoint();
    }

    public Vector3 GetPositionPointOnPlayer(PointForBlock pointForBlock)
    {
        return _pointsForBlock.FindPositionPointOnPlayer(pointForBlock);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointCreater : MonoBehaviour
{
    [SerializeField] private float _interval;
    [SerializeField] private Block _template;

    private Vector3 _newBlockPointPosition;




    public void CreateBlockPoint(Vector3 blockPointPosition)
    {
        _newBlockPointPosition = new Vector3(blockPointPosition.x, blockPointPosition.y + _interval, blockPointPosition.z);

        Instantiate(_template, _newBlockPointPosition, Quaternion.identity);
    }
}

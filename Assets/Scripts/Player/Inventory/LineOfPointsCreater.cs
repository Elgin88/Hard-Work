using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _template;
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private float _maxNumberLines;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();

        if (_template == null || _deltaBetweenBlocks ==0 || _maxNumberLines == 0)
        {
            Debug.Log("LineOfPointsCreater no SerializeField");
        }
    }

    public void TryCreateLine()
    {
        if (_inventory.CheckIsFull() == true)
        {
            if (_inventory.GetCountOfLines() <= _maxNumberLines)
            {
                LineOfPoints line = Instantiate(_template, _inventory.transform);
                line.MoveUp(_deltaBetweenBlocks);
                _inventory.AddLine(line);
            }
        }
    }
}
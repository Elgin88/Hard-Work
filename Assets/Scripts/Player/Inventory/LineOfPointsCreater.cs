using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _template;
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private int _maxNumberLines;

    public int MaxNumberLines => _maxNumberLines;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public void CreateLine()
    {
        if (_inventory.GetCountOfLines() <= _maxNumberLines)
        {
            LineOfPoints line = Instantiate(_template, _inventory.transform);
            line.MoveUp(_deltaBetweenBlocks * _inventory.GetCountOfLines());

            _inventory.AddLine(line);
        }
    }
}
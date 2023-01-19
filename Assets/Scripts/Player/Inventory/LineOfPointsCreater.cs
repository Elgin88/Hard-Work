using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _template;
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private int _maxNumberLines;
    [SerializeField] private int _numberLinePerBuy;

    public int MaxNumberLines => _maxNumberLines;

    private Inventory _inventory;

    private void Start()
    {
        if (_template == null || _deltaBetweenBlocks == 0 || _maxNumberLines == 0 || _numberLinePerBuy == 0)
            Debug.Log("No SerializeField in " + this.name);

        _inventory = GetComponentInParent<Inventory>();
    }

    public void TryCreateLine()
    {
        if (_inventory.GetCountOfLines() <= _maxNumberLines)
        {
            LineOfPoints line = Instantiate(_template, _inventory.transform);
            line.MoveUp(_deltaBetweenBlocks * _inventory.GetCountOfLines());

            _inventory.AddLine(line);
        }
    }

    public void AddLine()
    {
        _maxNumberLines += _numberLinePerBuy;
    }
}
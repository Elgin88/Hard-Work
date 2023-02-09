using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _template;
    [SerializeField] private float _deltaBetweenBlocks;
    [SerializeField] private int _maxNumberOfLines;

    private Inventory _inventory;

    public int MaxNumberOfLines => _maxNumberOfLines;
    public event UnityAction <int, int> IsChangedMaxNumberLines;

    private void Start()
    {
        if (_template == null || _deltaBetweenBlocks == 0 || _maxNumberOfLines == 0)
            Debug.Log("No SerializeField in " + this.name);

        _inventory = GetComponentInParent<Inventory>();
    }

    public void TryCreateLine()
    {
        if (_inventory.GetCountOfLines() <= _maxNumberOfLines)
        {
            LineOfPoints line = Instantiate(_template, _inventory.transform);
            line.MoveUp(_deltaBetweenBlocks * _inventory.GetCountOfLines());

            _inventory.AddLine(line);
        }
    }

    public void LevelUo(int numberNewOfLines)
    {
        _maxNumberOfLines += numberNewOfLines;
        IsChangedMaxNumberLines?.Invoke(_inventory.GetCurrentNumberOfBlocks(), _inventory.GetMaxNumberOfBlocks());
    }


}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineOfPointsCreater : MonoBehaviour
{
    private LineOfPoints _lineOfPoints;

    private float _rangeBetweenBlocks;
    private int _maxNumberOfLines;

    private Inventory _inventory;
    private Player _player;
    private Garage _garage;

    public int MaxNumberOfLines => _maxNumberOfLines;

    public event UnityAction <int, int> IsChangedMaxNumberBlocks;

    private void Start()
    {
        _inventory = GetComponentInParent<Inventory>();
        _player = FindObjectOfType<Player>();
        _garage = FindObjectOfType<Garage>();
        _lineOfPoints = FindObjectOfType<LineOfPoints>();

        _rangeBetweenBlocks = _player.RangeBetweenBlocks;
        _maxNumberOfLines = _player.MaxHightOfInventory;
    }

    public void TryCreateLine()
    {
        if (_inventory.GetCountOfLines() <= _maxNumberOfLines)
        {
            LineOfPoints line = Instantiate(_lineOfPoints, _inventory.transform);
            line.MoveUp(_rangeBetweenBlocks * _inventory.GetCountOfLines());

            _inventory.AddLine(line);
        }
    }

    public void TryAddPlace(int numberLines)
    {
        if (_player.Money > _garage.PlaceCost)
        {
            _maxNumberOfLines += numberLines;

            _player.RemoveMoney(_garage.PlaceCost);

            IsChangedMaxNumberBlocks?.Invoke(_inventory.GetCurrentNumberOfBlocks(), _inventory.GetMaxNumberOfBlocks());
        }
    }
}
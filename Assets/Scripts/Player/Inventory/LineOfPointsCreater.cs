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
    private Player _player;
    private Garage _garage;

    public int MaxNumberOfLines => _maxNumberOfLines;

    public event UnityAction <int, int> IsChangedMaxNumberBlocks;

    private void Start()
    {
        if (_template == null || _deltaBetweenBlocks == 0 || _maxNumberOfLines == 0)
            Debug.Log("No SerializeField in " + this.name);

        _inventory = GetComponentInParent<Inventory>();
        _player = FindObjectOfType<Player>();
        _garage = FindObjectOfType<Garage>();
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
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
    private Coroutine _createLineWork;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();

        if (_template == null || _deltaBetweenBlocks == 0 || _maxNumberLines==0)
            Debug.Log("No SerializeField in LineOfPointsCreater ");

        StartCoroutineCreateLine();
    }

    public IEnumerator CreateLine()
    {
        while (true)
        {
            if (_inventory.CheckIsInventoryFull() == true)
            {
                Debug.Log("Inventory - " + _inventory.CheckIsInventoryFull());

                if (_inventory.GetCountLines() < _maxNumberLines)
                {
                    LineOfPoints tempLineOfPoints = Instantiate(_template, _inventory.transform);
                    tempLineOfPoints.MoveUp(_deltaBetweenBlocks * _inventory.GetCountLines());
                    _inventory.AddLine(tempLineOfPoints);
                }
            }

            yield return null;
        }        
    }

    public void StartCoroutineCreateLine()
    {
        _createLineWork = StartCoroutine(CreateLine());
    }

    public void StopCoroutineCreateLine()
    {
        StopCoroutine(_createLineWork);
    }
}
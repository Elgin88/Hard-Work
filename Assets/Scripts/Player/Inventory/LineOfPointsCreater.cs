using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class LineOfPointsCreater : MonoBehaviour
{
    [SerializeField] private LineOfPoints _template;

    private Inventory _inventory;
    private Coroutine _createLineWork;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public IEnumerator CreateLine()
    {
        while (true)
        {
            for (int i = 0; i < _inventory.GetCountLines(); i++)
            {
                if (_inventory.IsTaken(i) == true)
                {
                    LineOfPoints tempLineOfPoints = Instantiate(_template, _inventory.transform);
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
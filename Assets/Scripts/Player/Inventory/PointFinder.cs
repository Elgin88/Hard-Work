using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class PointFinder : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public Point TryTakePoint()
    {
        for (int i = 0; i < _inventory.GetCountLines(); i++)
        {
            if (_inventory.IsTaken(i) == false)
            {
                return _inventory.TryTakePoint(i);
            }
        }

        return null;        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class Unloader : MonoBehaviour
{
    private Coroutine _unload;
    private CollectionPoint _point;
    private Inventory _inventory;

    private bool _isUnload;

    private bool IsUnload => _isUnload;

    private void Start()
    {
        _point = FindObjectOfType<CollectionPoint>();
        _inventory = GetComponent<Inventory>();

        _isUnload = false;
    }

    private IEnumerator Unload()
    {
        _isUnload = true;

        while (true)
        {
            Block lastAddBlock = _inventory.TryGetLastAddBlock();

            if (lastAddBlock != null)
            {
                lastAddBlock.BlockMoverToCollector.StartCoroutineMoveToCollector(_point.transform.position);
                lastAddBlock.Point.RemoveBlock();

                if (_inventory.GetNumberBloksInTopLine() == 0 & _inventory.GetCountOfLines() > 1)
                {
                    _inventory.RemoveTopLine();
                }

                if (_inventory.GetCurrentNumberOfBlocks () == 0)
                {
                    _isUnload = false;
                    StopUnload();
                }
            }

            yield return null;
        }
    }

    private void StartUnload()
    {
        if (_unload == null)
        {
            _unload = StartCoroutine(Unload());
        }
    }

    private void StopUnload()
    {
        if (_unload != null)
        {
            StopCoroutine(_unload);
            _unload = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class Unloader : MonoBehaviour
{
    [SerializeField] private float _speedUnload;

    private Coroutine _unload;
    private CollectionPoint _point;
    private Inventory _inventory;
    private WaitForSeconds _speedUnloadWFS;

    private void Start()
    {
        if (_speedUnload == 0)
        {
            Debug.Log("No SerializeField in" + gameObject.name);
        }

        _point = FindObjectOfType<CollectionPoint>();
        _inventory = GetComponent<Inventory>();

        _speedUnloadWFS = new WaitForSeconds(_speedUnload);
    }

    private IEnumerator Unload()
    {
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
                    StopUnload();
                }
            }

            yield return _speedUnloadWFS;

        }
    }

    public void StartUnload()
    {
        if (_unload == null)
        {
            _unload = StartCoroutine(Unload());
        }
    }

    public void StopUnload()
    {
        if (_unload != null)
        {
            StopCoroutine(_unload);
            _unload = null;
        }
    }
}

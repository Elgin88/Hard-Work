using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unloader : MonoBehaviour
{

    private float _deltaBetweenUnloadBlocks;
    private Coroutine _unload;
    private CollectionPoint _point;
    private Inventory _inventory;
    private WaitForSeconds _deltaBetweenUnloadBlocksWFS;

    private void Start()
    {
        _point = FindObjectOfType<CollectionPoint>();
        _deltaBetweenUnloadBlocks = FindObjectOfType<Player>().DeltaBetweenUnloadBlocks;

        _inventory = GetComponent<Inventory>();
        

        _deltaBetweenUnloadBlocksWFS = new WaitForSeconds(_deltaBetweenUnloadBlocks);
    }

    private IEnumerator Unload()
    {
        while (true)
        {
            Block lastAddBlock = _inventory.TryGetLastAddBlock();

            if (lastAddBlock != null)
            {
                lastAddBlock.BlockMoverToCollector.StartMoveToCollector(_point.transform.position);
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

            yield return _deltaBetweenUnloadBlocksWFS;

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

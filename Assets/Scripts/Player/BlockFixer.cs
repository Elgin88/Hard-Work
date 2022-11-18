using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockFixer : MonoBehaviour
{
    private Coroutine _fixBlock;

    private void Start()
    {
        
    }

    private IEnumerator FixBlock(Block block)
    {
        while (true)
        {
            
            


            yield return null;
        }
    }

    public void StartCoroutineSetBlock(Block block)
    {
        if (_fixBlock == null)
        {
            _fixBlock = StartCoroutine(FixBlock(block));
        }
    }

    public void StopCoroutineSetBlock()
    {
        if (_fixBlock != null)
        {
            StopCoroutine(_fixBlock);
            _fixBlock = null;
        }
    }
}

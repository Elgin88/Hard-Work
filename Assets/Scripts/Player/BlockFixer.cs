using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockFixer : MonoBehaviour
{
    private Coroutine _setBlockWork;

    private void Start()
    {
        //StartCoroutineSetBlock();
    }

    private IEnumerator SetBlock()
    {
        while (true)
        {
            //В работе

            yield return null;
        }
    }

    public void StartCoroutineSetBlock()
    {
        if (_setBlockWork == null)
        {
            _setBlockWork = StartCoroutine(SetBlock());
        }
    }

    public void StopCoroutineSetBlock()
    {
        if (_setBlockWork != null)
        {
            StopCoroutine(_setBlockWork);
            _setBlockWork = null;
        }
    }
}

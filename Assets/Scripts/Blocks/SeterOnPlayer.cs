using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeterOnPlayer : MonoBehaviour
{
    private Coroutine _setBlock = null;

    private IEnumerator SetBlock()
    {
        while (true)
        {






            yield return null;
        }
    }

    public void StartCoroutineSetBlock()
    {
        if (_setBlock == null)
        {
            _setBlock = StartCoroutine(SetBlock());
        }
    }

    public void StopCoroutineSetBlock()
    {
        if (_setBlock != null)
        {
            StopCoroutine(_setBlock);
            _setBlock = null;
        }
    }
}

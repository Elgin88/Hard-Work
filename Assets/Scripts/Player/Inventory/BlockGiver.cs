using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]

public class BlockGiver : MonoBehaviour
{
    private Inventory _inventory;
    private Coroutine _giveBlockCoroutine;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public IEnumerator GiveBlock()
    {
        while (true)
        {


            yield return null;
        }
    }

    public void StartCoroutineGiveBlock()
    {
        if (_giveBlockCoroutine == null)
        {
            _giveBlockCoroutine = StartCoroutine(GiveBlock());
        }
    }

    private void StopCoroutineGiveBlock()
    {
        if (_giveBlockCoroutine != null)
        {
            StopCoroutine(_giveBlockCoroutine);
            _giveBlockCoroutine = null;
        }
    }


}

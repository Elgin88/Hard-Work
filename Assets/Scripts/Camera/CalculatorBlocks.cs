using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculatorBlocks : MonoBehaviour
{
    private int _all;
    private int _unload;

    public int AllBlocks => _all;
    public int Unload => _unload;


    public event UnityAction <int, int> IsChangedUnload;

    private void Start()
    {
        _all = FindObjectsOfType<Block>().Length;

        _unload = 0;
    }

    public void AddUnloadBloks()
    {
        _unload++;
        IsChangedUnload?.Invoke(_unload, _all);
    }
}

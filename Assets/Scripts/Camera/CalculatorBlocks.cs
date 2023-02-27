using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculatorBlocks : MonoBehaviour
{
    private int _allBlocks;
    private int _unloadBlocks;

    public int NumberAllBlocks => _allBlocks;

    public event UnityAction <int, int> IsChangedUnloadBlocks;

    private void Start()
    {
        _allBlocks = FindObjectsOfType<Block>().Length;

        _unloadBlocks = 0;
    }

    public void AddUnloadBloks()
    {
        _unloadBlocks++;
        IsChangedUnloadBlocks?.Invoke(_unloadBlocks, _allBlocks);
    }
}

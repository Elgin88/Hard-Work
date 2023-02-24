using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorBlocks : MonoBehaviour
{
    private int _allBlocks;
    private int _unloadBlocks;

    public int NumberAllBlocks => _allBlocks;

    private void Start()
    {
        _allBlocks = FindObjectsOfType<Block>().Length;

        _unloadBlocks = 0;
    }

    public void AddUnloadBloks()
    {
        _unloadBlocks++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorBlocks : MonoBehaviour
{
    private int _numberBlocks;

    public int NumberBlocks => _numberBlocks;

    private void Start()
    {
        _numberBlocks = FindObjectsOfType<Block>().Length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculatorBlocks : MonoBehaviour
{
    private SectionOfBlocks[] _allSections;
    private Block[] _freeBlocks;
    private int _allBlocksInSections;
    private int _numberUnloadBlocks;
    private int _allBlocks;

    public event UnityAction <int> IsChangedNumberUnloadBlocks;
    public int AllBlocks => _allBlocks;
    public int Unload => _numberUnloadBlocks;

    private void Start()
    {
        _allSections = FindObjectsOfType<SectionOfBlocks>();
        _freeBlocks = FindObjectsOfType<Block>();

        foreach (SectionOfBlocks section in _allSections)
        {
            _allBlocksInSections += section.NumberOfBlocks;
        }

        _allBlocks = _allBlocksInSections + _freeBlocks.Length;
    }

    public void CalculateUnloadBloks()
    {
        _numberUnloadBlocks++;
        IsChangedNumberUnloadBlocks?.Invoke(_numberUnloadBlocks);
    }
}

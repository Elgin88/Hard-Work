using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculatorBlocks : MonoBehaviour
{
    private int _allBlocks;
    private int _allBloksInSection;
    private int _unload;
    private SectionOfBlocks[] _allSectionsBlocks;
    private Block [] allBlocks;

    public int AllBlocks => _allBlocks;
    public int Unload => _unload;

    public event UnityAction <int, int> IsChangedUnload;

    private void Start()
    {
        _allSectionsBlocks = FindObjectsOfType<SectionOfBlocks>();
        allBlocks = FindObjectsOfType<Block>();

        foreach (SectionOfBlocks sectionOfBlocks in _allSectionsBlocks)
        {
            _allBloksInSection += sectionOfBlocks.GetCountBlocks();
        }

        _allBlocks = _allBloksInSection + allBlocks.Length;
        _unload = 0;
    }

    public void AddUnloadBloks()
    {
        _unload++;
        IsChangedUnload?.Invoke(_unload, _allBlocks);
    }
}

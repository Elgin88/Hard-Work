using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnderLevel : MonoBehaviour
{
    [SerializeField] private int _maxProcent;
    [SerializeField] private int _middleProcent;
    [SerializeField] private int _minProcent;
    [SerializeField] private ReloadButton _reloadButton;
    [SerializeField] private EndLevelButton _endLevelButton;

    private CalculatorBlocks _calculatorBlocks;
    private int _maxNumberBlocks;
    private int _middleNumberBlocks;
    private int _minNumberBlocks;

    public int MaxNumberBlocks => _maxNumberBlocks;
    public int MiddleNumberBlocks => _middleNumberBlocks;
    public int MinNumberBlocks => _minNumberBlocks;

    private void Start()
    {
        if (_maxProcent == 0 || _middleProcent == 0 || _minProcent == 0 || _reloadButton == null || _endLevelButton == null)
        {
            Debug.Log("No SerializeField in" + gameObject.name);
        }

        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();

        _maxNumberBlocks = _calculatorBlocks.NumberAllBlocks;
        _middleNumberBlocks = _calculatorBlocks.NumberAllBlocks * _middleProcent / 100;
        _minNumberBlocks = _calculatorBlocks.NumberAllBlocks * _minProcent / 100;
    }
}
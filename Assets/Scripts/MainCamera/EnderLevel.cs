using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CalculatorBlocks))]
[RequireComponent(typeof(ChooserMedals))]
[RequireComponent(typeof(GameRequireComponents))]

public class EnderLevel : MonoBehaviour
{
    [SerializeField] private int _maxProcent;
    [SerializeField] private int _middleProcent;
    [SerializeField] private int _minProcent;
    [SerializeField] private string _nextScene;

    private ReloadButton _reloadButton;
    private EndLevelButton _endLevelButton;
    private EndLevelPanel _endLevelPanel;
    private GameRequireComponents _gameRequireComponents;

    private CalculatorBlocks _calculatorBlocks;
    private ChooserMedals _chooserMedals;
    private int _maxNumberBlocks;
    private int _middleNumberBlocks;
    private int _minNumberBlocks;

    public int MaxNumberBlocks => _maxNumberBlocks;
    public int MiddleNumberBlocks => _middleNumberBlocks;
    public int MinNumberBlocks => _minNumberBlocks;
    public string NextScene => _nextScene;
    public int MaxProcent => _maxProcent;
    public int MiddleProcent => _middleProcent;
    public int MinProcent => _minProcent;


    private void OnEnable()
    {
        _reloadButton = FindObjectOfType<ReloadButton>();

        _gameRequireComponents = GetComponent<GameRequireComponents>();
        _calculatorBlocks = GetComponent<CalculatorBlocks>();
        _chooserMedals = GetComponent<ChooserMedals>();
        
        _endLevelButton = _gameRequireComponents.EndLevelButton;
        _endLevelPanel = _gameRequireComponents.EndLevelPanel;
        
        _middleNumberBlocks = _calculatorBlocks.AllBlocks * _middleProcent / 100;
        _minNumberBlocks = _calculatorBlocks.AllBlocks * _minProcent / 100;

        _calculatorBlocks.IsChangedUnload += OnChangedNumberUnloadBlocks;
    }

    private void OnChangedNumberUnloadBlocks(int unloadBlocks, int allBlocks)
    {
        if (unloadBlocks >= _minNumberBlocks)
        {
            _reloadButton.gameObject.SetActive(false);
            _endLevelButton.gameObject.SetActive(true);
            _maxNumberBlocks = allBlocks;

            if (unloadBlocks == allBlocks)
            {
                _endLevelPanel.gameObject.SetActive(true);                
            }
        }
    }
}
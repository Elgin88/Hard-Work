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
    private int _allBlocks;
    private int _middleNumberBlocks;
    private int _minNumberBlocks;

    public int MaxNumberBlocks => _allBlocks;
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

        _calculatorBlocks.IsChangedNumberUnloadBlocks += OnChangedNumberUnloadBlocks;
    }

    private void OnDisable()
    {
        _calculatorBlocks.IsChangedNumberUnloadBlocks -= OnChangedNumberUnloadBlocks;
    }

    private void OnChangedNumberUnloadBlocks(int unloadBlocks)
    {
        if (_allBlocks == 0)
        {
            _allBlocks = _calculatorBlocks.AllBlocks;
            _middleNumberBlocks = _allBlocks * _middleProcent / 100;
            _minNumberBlocks = _allBlocks * _minProcent / 100;
        }

        if (unloadBlocks >= _minNumberBlocks)
        {
            _reloadButton.gameObject.SetActive(false);
            _endLevelButton.gameObject.SetActive(true);

            if (unloadBlocks == _allBlocks)
            {
                _endLevelPanel.gameObject.SetActive(true);                
            }
        }
    }
}
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
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private string _nextScene;

    private CalculatorBlocks _calculatorBlocks;
    private ChooserMedals _chooserMedals;
    private int _maxNumberBlocks;
    private int _middleNumberBlocks;
    private int _minNumberBlocks;

    public int MaxNumberBlocks => _maxNumberBlocks;
    public int MiddleNumberBlocks => _middleNumberBlocks;
    public int MinNumberBlocks => _minNumberBlocks;
    public string NextScene => _nextScene;

    private void Start()
    {
        _calculatorBlocks = FindObjectOfType<CalculatorBlocks>();
        _chooserMedals = FindObjectOfType<ChooserMedals>();

        _maxNumberBlocks = _calculatorBlocks.AllBlocks;
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
            _chooserMedals.ChooseMedals();

            if (unloadBlocks == allBlocks)
            {
                _endLevelPanel.gameObject.SetActive(true);
            }
        }
    }
}
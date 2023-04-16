using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooserMedals : MonoBehaviour
{
    [SerializeField] private MaxMedal _maxMedal;
    [SerializeField] private MiddleMedal _middleMedal;
    [SerializeField] private MinMedal _minMedal;

    private EnderLevel _enderLevel;
    private CalculatorBlocks _calculatorBlocks;

    private void OnEnable()
    {
        _enderLevel = FindObjectOfType<GameController>().GetComponent<EnderLevel>();
        _calculatorBlocks = FindObjectOfType<GameController>().GetComponent<CalculatorBlocks>();
    }

    private void Start()
    {
        if (_maxMedal == null || _middleMedal == null || _minMedal == null || _calculatorBlocks == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    public void ChooseMedals()
    {
        if (_calculatorBlocks.Unload >= _enderLevel.MinNumberBlocks)
        {
            _minMedal.gameObject.SetActive(true);

            if (_calculatorBlocks.Unload >= _enderLevel.MiddleNumberBlocks)
            {
                _middleMedal.gameObject.SetActive(true);

                if (_calculatorBlocks.Unload == _enderLevel.MaxNumberBlocks)
                {
                    _maxMedal.gameObject.SetActive(true);
                }
            }
        }
    }
}
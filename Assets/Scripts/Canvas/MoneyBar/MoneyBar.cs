using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    private MoneyBarCount _moneyBarCount;
    private TMP_Text _textMoney;
    private Player _player;
    private GameRequireComponents _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();

        _moneyBarCount = _gameRequireComponents.MoneyBarCount;
        _textMoney = _moneyBarCount.GetComponent<TMP_Text>();
        _player = _gameRequireComponents.Player;

        _player.IsMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _textMoney.text = money.ToString();
    }
}
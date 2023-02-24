using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    private MoneyBarCount _moneyBarCount;
    private TMP_Text _textMoney;
    private Player _player;

    private void OnEnable()
    {
        if (_moneyBarCount == null || _textMoney == null || _player == null)
        {
            _moneyBarCount = GetComponentInChildren<MoneyBarCount>();
            _textMoney = _moneyBarCount.GetComponent<TMP_Text>();
            _player = FindObjectOfType<Player>();
        }

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
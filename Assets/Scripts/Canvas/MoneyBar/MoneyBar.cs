using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;

    private Player _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _player.IsMoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}
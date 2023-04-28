using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;   

    private Player _player;
    private PlayerUpgrader _playerUpgrade;
    private Garage _garage;

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrade = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
        }

        _label.text = _garage.TankLabel;
        _cost.text = _garage.TankCost.ToString();
        _button.onClick.AddListener(OnAddTankButton);

        _player.IsMoneyChanged += OnPlayerMoneyChanded;

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddTankButton);
        _player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddTankButton()
    {
        _playerUpgrade.TryBuyTank();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_player.Money > _garage.TankCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
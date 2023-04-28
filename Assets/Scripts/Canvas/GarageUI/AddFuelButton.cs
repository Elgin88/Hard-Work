using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddFuelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;

    private Garage _garage;
    private Player _player;
    private PlayerUpgrader _playerUpgrade;

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrade = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
        }

        _button.onClick.AddListener(OnAddFuelButtonClick);
        _player.IsMoneyChanged += OnPlayerMoneyChanded;

        _label.text = _garage.FuelLabel;
        _cost.text = _garage.FuelCoust.ToString();

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddFuelButtonClick);
        _player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddFuelButtonClick()
    {
        _playerUpgrade.TryBuyFuel();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_player.Money > _garage.FuelCoust)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}

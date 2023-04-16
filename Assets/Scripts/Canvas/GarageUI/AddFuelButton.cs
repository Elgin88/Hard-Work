using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddFuelButton : MonoBehaviour
{
    private Button _addFuelButton;
    private TMP_Text _label;
    private TMP_Text _cost;
    private Garage _garage;
    private Player _player;
    private PlayerUpgrader _playerUpgrade;
    private GameRequireComponents _gameRequireComponents;

    private Coroutine _setStatusButton;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
        _garage = _gameRequireComponents.Garage;
        _player = _gameRequireComponents.Player;
        _playerUpgrade = _gameRequireComponents.PlayerUpgrade;

        _addFuelButton = GetComponent<Button>();
        _label = GetComponentInChildren<AddFuelButtonLabel>().GetComponent<TMP_Text>();
        _cost = GetComponentInChildren<AddFuelButtonCost>().GetComponent<TMP_Text>();

        _addFuelButton.onClick.AddListener(OnAddFuelButtonClick);
        _player.IsMoneyChanged += OnPlayerMoneyChanded;

        _label.text = _garage.FuelLabel;
        _cost.text = _garage.FuelCoust.ToString();

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _addFuelButton.onClick.RemoveListener(OnAddFuelButtonClick);
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
            _addFuelButton.interactable = true;
        }
        else
        {
            _addFuelButton.interactable = false;
        }
    }
}

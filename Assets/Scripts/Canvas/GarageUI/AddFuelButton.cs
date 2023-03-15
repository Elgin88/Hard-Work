using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddFuelButton : MonoBehaviour
{
    [SerializeField] private Button _addFuelButton;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Garage _garage;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUpgrader _playerUpgrade;

    private Coroutine _setStatusButton;

    private void Start()
    {
        if (_addFuelButton==null|| _label == null || _cost == null || _garage == null || _playerUpgrade == null || _player == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
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

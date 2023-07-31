using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddFuelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;

    private Button _button;
    private Garage _garage;
    private GarageSoundController _garageSoundController;
    private Player _player;
    private PlayerUpgrader _playerUpgrade;
    private CanvasSoundController _sound;

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrade = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
            _sound = FindObjectOfType<CanvasSoundController>();
            _button = GetComponent<Button>();
            _garageSoundController = FindObjectOfType<GarageSoundController>();
        }

        _button.onClick.AddListener(OnAddFuelButtonClick);
        _player.IsMoneyChanged += OnPlayerMoneyChanded;

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
        _sound.PlayBuySound();

        _garageSoundController.PlayFuelSound();
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

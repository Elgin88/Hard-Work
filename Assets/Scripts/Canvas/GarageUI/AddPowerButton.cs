using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPowerButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;

    private Player _player;
    private PlayerUpgrader _playerUpgrader;
    private Garage _garage;

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrader = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
        }

        _button.onClick.AddListener(OnButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;

        _label.text = _garage.PowerLabel;
        _cost.text = _garage.PowerCost.ToString();

        CheckButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnButtonClick()
    {
        _playerUpgrader.TryAddPower();
    }

    private void OnMoneyChanged(int money)
    {
        CheckButton();
    }

    private void CheckButton()
    {
        if (_player.Money > _garage.PowerCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
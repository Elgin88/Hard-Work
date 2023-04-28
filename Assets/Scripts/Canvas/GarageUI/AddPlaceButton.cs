using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AddPlaceButton : MonoBehaviour
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

        _button.onClick.AddListener(OnAddPlaceButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;

        _label.text = _garage.PlaceLabel;
        _cost.text = _garage.PlaceCost.ToString();

        SetStatusButton();        
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddPlaceButtonClick);
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnAddPlaceButtonClick()
    {
        _playerUpgrader.TryAddPlace();
    }

    private void OnMoneyChanged(int money)
    {
        SetStatusButton();
    }

    private void  SetStatusButton()
    {
        if (_player.Money > _garage.PlaceCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
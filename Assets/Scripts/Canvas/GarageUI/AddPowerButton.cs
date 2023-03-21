using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPowerButton : MonoBehaviour
{
    [SerializeField] private Button _addPowerButton;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUpgrader _upgrader;
    [SerializeField] private Garage _garage;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;

    private void OnEnable()
    {
        if (_addPowerButton == null || _player == null || _upgrader == null || _garage == null || _label == null || _cost == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        _addPowerButton.onClick.AddListener(OnButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;


        _label.text = _garage.PowerLabel;
        _cost.text = _garage.PowerCost.ToString();

        CheckButton();
    }

    private void OnDisable()
    {
        _addPowerButton.onClick.RemoveListener(OnButtonClick);
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnButtonClick()
    {
        _upgrader.TryAddPower();
    }

    private void OnMoneyChanged(int money)
    {
        CheckButton();
    }

    private void CheckButton()
    {
        if (_player.Money > _garage.PowerCost)
        {
            _addPowerButton.interactable = true;
        }
        else
        {
            _addPowerButton.interactable = false;
        }
    }
}
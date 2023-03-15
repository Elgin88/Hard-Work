using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Garage _garage;
    [SerializeField] private Button _addTankButton;
    [SerializeField] private PlayerUpgrader _playerUpgrade;
    [SerializeField] private Player _player;

    private void Start()
    {
        if (_label == null || _cost == null || _garage == null || _addTankButton == null || _playerUpgrade == null || _player == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _label.text = _garage.TankLabel;
        _cost.text = _garage.TankCost.ToString();
        _addTankButton.onClick.AddListener(OnAddTankButton);

        _player.IsMoneyChanged += OnPlayerMoneyChanded;
        CheckStatusButton();
    }

    private void OnDisable()
    {
        _addTankButton.onClick.RemoveListener(OnAddTankButton);
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
            _addTankButton.interactable = true;
        }
        else
        {
            _addTankButton.interactable = false;
        }
    }
}
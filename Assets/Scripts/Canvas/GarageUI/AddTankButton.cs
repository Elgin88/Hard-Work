using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Garage _garage;
    [SerializeField] private Button _addTankButton;
    [SerializeField] private PlayerUpgrade _playerUpgrade;

    private void Start()
    {
        if (_label == null || _cost == null || _garage == null || _addTankButton == null || _playerUpgrade == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _label.text = _garage.TankLabel;
        _cost.text = _garage.TankCost.ToString();
        _addTankButton.onClick.AddListener(OnAddTankButton);
    }

    private void OnDisable()
    {
        _addTankButton.onClick.RemoveListener(OnAddTankButton);
    }

    private void OnAddTankButton()
    {
        _playerUpgrade.AddTank();
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPlaceButton : MonoBehaviour
{
    [SerializeField] private Button _addPlaceButton;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerUpgrader _upgrader;
    [SerializeField] private Garage _garage;

    private void Start()
    {
        if (_addPlaceButton==null|| _label == null || _cost == null || _player == null || _upgrader == null || _garage == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        _addPlaceButton.onClick.AddListener(OnAddPlaceButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;

        _label.text = _garage.PlaceLabel;
        _cost.text = _garage.PlaceCost.ToString();

        SetStatusButton();        
    }

    private void OnDisable()
    {
        _addPlaceButton.onClick.RemoveListener(OnAddPlaceButtonClick);
        _player.IsMoneyChanged -= OnMoneyChanged;
    }

    private void OnAddPlaceButtonClick()
    {
        _upgrader.TryAddPlace();
    }

    private void OnMoneyChanged(int money)
    {
        SetStatusButton();
    }

    private void  SetStatusButton()
    {
        if (_player.Money > _garage.PlaceCost)
        {
            _addPlaceButton.interactable = true;
        }
        else
        {
            _addPlaceButton.interactable = false;
        }
    }
}
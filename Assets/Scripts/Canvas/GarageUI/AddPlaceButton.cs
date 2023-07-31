using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AddPlaceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Flasher _maxTextFlasher;
    [SerializeField] private Flasher _middleTextFlasher;
    [SerializeField] private Flasher _minTextFlasher;

    private Button _button;
    private Player _player;
    private PlayerUpgrader _playerUpgrader;
    private Garage _garage;
    private GarageSoundController _garageSoundController;
    private CanvasSoundController _soundController;

    private void OnEnable()
    {
        _button = GetComponent<Button>();

        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrader = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
            _soundController = FindObjectOfType<CanvasSoundController>();
            _garageSoundController = FindObjectOfType<GarageSoundController>();
        }

        _button.onClick.AddListener(OnAddPlaceButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;

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
        _soundController.PlayBuySound();

        _maxTextFlasher.StartFlash();
        _middleTextFlasher.StartFlash();
        _minTextFlasher.StartFlash();

        _garageSoundController.StartPlaySoundFinEngine();
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
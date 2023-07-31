using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTankButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Flasher _maxTextFlasher;
    [SerializeField] private Flasher _middleTextFlasher;
    [SerializeField] private Flasher _minTextFlasher;

    private Button _button;
    private Player _player;
    private PlayerUpgrader _playerUpgrade;
    private Garage _garage;
    private GarageSoundController _garageSoundController;
    private CanvasSoundController _soundController;

    private void OnEnable()
    {
        _button = GetComponent<Button>();

        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrade = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
            _soundController = FindObjectOfType<CanvasSoundController>();
            _garageSoundController = FindObjectOfType<GarageSoundController>();
        }

        _cost.text = _garage.TankCost.ToString();
        _button.onClick.AddListener(OnAddTankButton);

        _player.IsMoneyChanged += OnPlayerMoneyChanded;

        CheckStatusButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnAddTankButton);
        _player.IsMoneyChanged -= OnPlayerMoneyChanded;
    }

    private void OnAddTankButton()
    {
        _playerUpgrade.TryBuyTank();
        _soundController.PlayBuySound();
        _maxTextFlasher.StartFlash();
        _middleTextFlasher.StartFlash();
        _minTextFlasher.StartFlash();
        _garageSoundController.StartPlaySoundFinEngine();
    }

    private void OnPlayerMoneyChanded(int money)
    {
        CheckStatusButton();
    }

    private void CheckStatusButton()
    {
        if (_player.Money > _garage.TankCost)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
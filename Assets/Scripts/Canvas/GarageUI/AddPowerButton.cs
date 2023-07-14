using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddPowerButton : MonoBehaviour
{

    [SerializeField] private TMP_Text _cost;

    private Button _button;
    private Player _player;
    private PlayerUpgrader _playerUpgrader;
    private Garage _garage;
    private PlayerPowerController _powerController;
    private bool _isMaxLevelEngine;
    private EngineBarIconFlash _flash;
    private CanvasSoundController _soundController;

    private void OnEnable()
    {
        _button = GetComponent<Button>();

        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _playerUpgrader = _player.GetComponent<PlayerUpgrader>();
            _garage = FindObjectOfType<Garage>();
            _powerController = FindObjectOfType<PlayerPowerController>();
            _flash = FindObjectOfType<EngineBarIconFlash>();
            _soundController = FindObjectOfType<CanvasSoundController>();
        }

        _button.onClick.AddListener(OnButtonClick);
        _player.IsMoneyChanged += OnMoneyChanged;
        _powerController.IsEngineUpgrade += OnEngineLevelChanged;

        _cost.text = _garage.PowerCost.ToString();

        CheckButton();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _player.IsMoneyChanged -= OnMoneyChanged;
        _powerController.IsEngineUpgrade -= OnEngineLevelChanged;
    }

    private void OnButtonClick()
    {
        _playerUpgrader.TryAddPower();
        _soundController.PlayBuySound();
    }

    private void OnMoneyChanged(int money)
    {
        CheckButton();
    }

    private void OnEngineLevelChanged(int level, bool isMaxLevel)
    {
        _isMaxLevelEngine = isMaxLevel;
        CheckButton();
    }

    private void CheckButton()
    {
        if (_player.Money > _garage.PowerCost & _isMaxLevelEngine == false)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
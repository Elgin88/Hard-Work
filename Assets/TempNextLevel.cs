using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TempNextLevel : MonoBehaviour
{
    private Button _button;
    private GameRequireComponents _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_gameRequireComponents.EnderLevel.NextScene);
    }
}

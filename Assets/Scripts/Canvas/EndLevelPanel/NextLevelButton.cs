using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    private Button _nextLevelButton;
    private EnderLevel _enderLevel;
    private Player _player;

    private void OnEnable()
    {
        _enderLevel = FindObjectOfType<EnderLevel>();
        _player = FindObjectOfType<Player>();

        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        DataForNextScene.SetMoney(_player.Money);
        SceneManager.LoadScene(_enderLevel.NextScene);
    }
}

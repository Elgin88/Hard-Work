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
    private string _currentLevelName;

    private void OnEnable()
    {
        if (_player == null)
        {
            _enderLevel = FindObjectOfType<EnderLevel>();
            _player = FindObjectOfType<Player>();
        }

        _currentLevelName = SceneManager.GetActiveScene().name;

        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
    }

    private void OnNextLevelButtonClick()
    {
        SceneManager.LoadScene(_enderLevel.NextSceneName);        
    }

    private void ShowVideoInBrauser()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        VideoAd.Show();
#endif
    }
}

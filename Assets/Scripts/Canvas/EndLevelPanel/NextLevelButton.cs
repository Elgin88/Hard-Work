using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class NextLevelButton : MonoBehaviour
{
    private EnderLevel _enderLevel;
    private Button _nextLevelButton;
    private Player _player;
<<<<<<< HEAD

    private string _currentLevelName;

    private void OnEnable()
    {
        if (_player == null)
        {
            _enderLevel = FindObjectOfType<EnderLevel>();
            _player = FindObjectOfType<Player>();
        }

        _currentLevelName = SceneManager.GetActiveScene().name;
=======

    private void OnEnable()
    {
        _enderLevel = FindObjectOfType<EnderLevel>();
        _player = FindObjectOfType<Player>();
>>>>>>> parent of 81826e37 (1)

        _nextLevelButton = GetComponent<Button>();
        _nextLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
<<<<<<< HEAD
        SceneManager.LoadScene(_enderLevel.NextSceneName);
=======
        DataForNextScene.SetMoney(_player.Money);
<<<<<<< HEAD
        SceneManager.LoadScene(_enderLevel.NextScene);        

        ShowVideo();
>>>>>>> parent of 81826e37 (1)
    }

    private void ShowVideo()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.PlayerPrefs.Save();
        VideoAd.Show();
#endif
=======
        SceneManager.LoadScene(_enderLevel.NextScene);
>>>>>>> parent of 096c8651 (Версия до запекания света)
    }
}

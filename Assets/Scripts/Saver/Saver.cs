using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{
    private string _currentPlayerMoney = "currentPlayerMoney";
    private string _currentLevelName = "currentLevelName";
    private Player _player;
    private EnderLevel _endelLevel;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _endelLevel = FindObjectOfType<EnderLevel>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(_currentPlayerMoney, _player.Money);
        PlayerPrefs.SetString(_currentLevelName, _endelLevel.NextSceneName);
        PlayerPrefs.Save();

        SaveDataInCloud();
    }

    public void SaveDataInCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.PlayerPrefs.Save();
#endif
    }
}
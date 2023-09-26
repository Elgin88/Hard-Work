using UnityEngine;

public class Loader : MonoBehaviour
{
    private string _currentPlayerMoney = "currentPlayerMoney";
    private string _currentLevelName = "currentLevelName";

    public int GetSavedDataCurrentPlayerMoney()
    {
        LoadPlayersPrefsFromCloud();

        return PlayerPrefs.GetInt(_currentPlayerMoney);
    }

    public string GetSavedDataLevelName()
    {
        LoadPlayersPrefsFromCloud();

        return PlayerPrefs.GetString(_currentLevelName);
    }

    public void LoadPlayersPrefsFromCloud()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        Agava.YandexGames.PlayerPrefs.Load();
#endif
    }
}
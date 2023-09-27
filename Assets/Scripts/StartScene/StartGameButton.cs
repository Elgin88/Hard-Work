using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private AudioSource _soundOfClick;
    [SerializeField] private TMP_Text _debugText1;
    [SerializeField] private TMP_Text _debugText2;
    [SerializeField] private TMP_Text _debugText3;
    [SerializeField] private TMP_Text _debugText4;

    private WaitForSeconds _delayLoadOfScene = new WaitForSeconds(0.5f);    
    private Coroutine _loadNextLevel;
    private string _sceneNameOfLevel1 = "Level1";
    private string _sceneNameForLoad = "";

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    private void Update()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        _debugText1.text = Agava.YandexGames.YandexGamesSdk.IsInitialized.ToString() + " - работа SDK";
#endif
    }

    private void OnStartGameButtonClick()
    {
        _soundOfClick.Play();

        _sceneNameForLoad = _sceneNameOfLevel1;

        SceneManager.LoadScene(_sceneNameForLoad);

        _startGameButton.onClick.RemoveListener(OnStartGameButtonClick);

        //_loadNextLevel = StartCoroutine(LoadNextLevel());
    }

    //private IEnumerator LoadNextLevel()
    //{
    //    _soundOfClick.Play();

    //    yield return _delayLoadOfScene;

    //    _nextSceneName = _loader.GetSavedSceneNameForLoad();

    //    if (_nextSceneName == "")
    //    {
    //        _nextSceneName = _level1SceneName;
    //    }
    //}
}
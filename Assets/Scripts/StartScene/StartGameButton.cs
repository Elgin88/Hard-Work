using System.Collections;
<<<<<<< HEAD
using TMPro;
=======
using System.Collections.Generic;
<<<<<<< HEAD
using Agava.YandexGames;
>>>>>>> parent of 81826e37 (1)
=======
>>>>>>> parent of 096c8651 (Версия до запекания света)
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class StartGameButton : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField] private string _nextLevel;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;

    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _loadScene;
>>>>>>> parent of 81826e37 (1)

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
<<<<<<< HEAD
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
=======
        _audio.Play();
        _loadScene = StartCoroutine(LoadScene());          
    }

    private IEnumerator LoadScene()
    {
        while (true)
        {
            yield return _delay;
            SceneManager.LoadScene(_nextLevel);
        }
    }
}
>>>>>>> parent of 81826e37 (1)

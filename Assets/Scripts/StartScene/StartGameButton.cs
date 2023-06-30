using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private string _nextLevel;
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audio;

    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private Coroutine _loadScene;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private EnderLevel _enderLevel;

    private void Start()
    {
        if (_nextLevelButton == null|| _enderLevel == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }       
    }

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_enderLevel.NextScene);
    }
}

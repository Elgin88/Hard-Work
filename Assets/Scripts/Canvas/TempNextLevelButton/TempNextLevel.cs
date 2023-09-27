using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TempNextLevel : MonoBehaviour
{
    private Button _button;
    private EnderLevel _enderLevel;

    private void OnEnable()
    {
        _enderLevel = FindObjectOfType<EnderLevel>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(_enderLevel.NextScene);
    }
}

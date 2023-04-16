using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class EndLevelButton : MonoBehaviour
{
    private EndLevelPanel _endLevelPanel;
    private Button _button;

    private void OnEnable()
    {
        _endLevelPanel = FindObjectOfType<GameController>().GetComponent<GameRequireComponents>().EndLevelPanel;
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
        _endLevelPanel.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (_button!=null)
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }        
    }

    private void OnButtonClick()
    {
        _endLevelPanel.gameObject.SetActive(true);
    }
}

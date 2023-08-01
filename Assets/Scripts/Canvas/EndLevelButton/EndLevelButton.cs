using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private Button _endLevelButton;
    [SerializeField] private EndLevelPanel _endLevelPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _endLevelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        if (_endLevelButton != null)
        {
            _endLevelButton.onClick.RemoveListener(OnButtonClick);
        }        
    }

    private void OnButtonClick()
    {
        _endLevelPanel.gameObject.SetActive(true);
    }
}

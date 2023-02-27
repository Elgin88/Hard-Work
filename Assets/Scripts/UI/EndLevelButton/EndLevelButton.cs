using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private EndLevelPanel _endLevelPanel;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener (OnButtonClick);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class EndLevelButton : MonoBehaviour
{
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private Button _button;

    private void Start()
    {
        if (_endLevelPanel == null)
        {
            Debug.Log("No SerilizeField in" + gameObject.name);
        }
    }

    private void OnEnable()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChooserMedals))]

public class GameRequireComponents : MonoBehaviour
{
    [SerializeField] private EndLevelPanel _endLevelPanel;
    [SerializeField] private EndLevelButton _endLevelButton;

    private ChooserMedals _chooserMedals;

    public EndLevelPanel EndLevelPanel => _endLevelPanel;
    public EndLevelButton EndLevelButton => _endLevelButton;
    public ChooserMedals ChooserMedals => _chooserMedals;

    private void Start()
    {
        _chooserMedals = GetComponent<ChooserMedals>();
    }
}

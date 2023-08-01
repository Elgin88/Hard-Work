using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    private GameRequireComponents _gameRequireComponents;

    public GameRequireComponents GameRequireComponents => _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();
    }

}

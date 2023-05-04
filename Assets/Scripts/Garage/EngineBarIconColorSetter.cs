using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineBarIconColorSetter : MonoBehaviour
{
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;

    private Image _image;
    private Color _currentColor;
    private Coroutine _changeColor;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            _image.CrossFadeColor(_targetColor, _duration, false, false);

            yield return null;
        }
    }

    public void StartChangeColor()
    {
        if (_changeColor == null)
        {
            _changeColor = StartCoroutine(ChangeColor());
        }
    }

    public void StopChangeColor()
    {
        if (_changeColor != null)
        {
            _changeColor = StartCoroutine(ChangeColor());
            _changeColor = null;
        }
    }
}

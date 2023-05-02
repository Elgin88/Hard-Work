using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinMedalUI : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ParticleSystem _sun;
    [SerializeField] private Image _image;

    private Coroutine _showMedal;

    private IEnumerator ShowMedal()
    {
        while (true)
        {
            _explosion.Play();
            _sun.Play();
            return null;
        }
    }

    public void StartShowMedal()
    {
        if (_showMedal ==null)
        {
            _showMedal = StartCoroutine(ShowMedal());
        }
    }

    public void StopShowMedal()
    {
        if (_showMedal!= null)
        {
            StopCoroutine(_showMedal);
            _showMedal = null;
        }
    }
}

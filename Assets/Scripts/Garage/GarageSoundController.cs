using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _fixEngineSound;
    [SerializeField] private int _countOfRepeatsFixEngineSound;
    [SerializeField] private float _delayBetweenFixEngineSound;

    [SerializeField] private AudioSource _fuelSound;

    private Coroutine _playSoundFixEngine;
    private WaitForSeconds _delayBeweenSoundWFS;

    private void Start()
    {
        _delayBeweenSoundWFS = new WaitForSeconds(_delayBetweenFixEngineSound);
    }

    public void PlayFuelSound()
    {
        _fuelSound.Play();
    }

    private IEnumerator PlayFixEngineSound()
    {
        int numberOfCircle = 0;

        while (true)
        {
            _fixEngineSound.Play();

            numberOfCircle++;

            if (numberOfCircle >= _countOfRepeatsFixEngineSound)
                StopPlaySoundFixEngine();

            yield return _delayBeweenSoundWFS;
        }
    }

    public void StartPlaySoundFinEngine()
    {
        if (_playSoundFixEngine == null)
        {
            _playSoundFixEngine = StartCoroutine(PlayFixEngineSound()); 
        }

    }

    public void StopPlaySoundFixEngine()
    {
        StopCoroutine(_playSoundFixEngine);
        _playSoundFixEngine = null;
    }
}
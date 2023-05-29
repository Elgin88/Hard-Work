using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _engineMinSound;
    [SerializeField] private AudioSource _engineMaxSound;

    public void PlayMinEngineSound()
    {
        if (_engineMinSound.isPlaying == false)
        {
            _engineMinSound.Play();
        }

        StopMaxEngineSound();
    }

    public void PlayMaxEngineSound()
    {
        if (_engineMaxSound.isPlaying==false)
        {
            _engineMaxSound.Play();            
        }

        StopMinEngineSound();
    }

    public void StopMinEngineSound()
    {
        _engineMinSound.Stop();
    }

    public void StopMaxEngineSound()
    {
        _engineMaxSound.Stop();
    }



    //private Coroutine _playEngineMinSound;
    //private Coroutine _playEngineMaxSound;




    //private IEnumerator PlayEngineMinSound()
    //{
    //    while (true)
    //    {
    //        _engineMinSound.Play();

    //        yield return null;
    //    }        
    //}

    //private IEnumerator PlayMinEngineMaxSound()
    //{
    //    while (true)
    //    {
    //        _engineMaxSound.Play();

    //        yield return null;
    //    }        
    //}

    //public void StartPlayEngineMinSound()
    //{
    //    if (_playEngineMinSound == null)
    //    {
    //        _playEngineMinSound = StartCoroutine(PlayEngineMinSound());
    //    }
    //}

    //public void StopPlayEngineMinSound()
    //{
    //    if (_playEngineMinSound != null)
    //    {
    //        StopCoroutine(_playEngineMinSound);
    //        _playEngineMinSound = null;
    //    }
    //}

    //public void StartPlayEngineMaxSound()
    //{
    //    if (_playEngineMaxSound == null)
    //    {
    //        _playEngineMaxSound = StartCoroutine(PlayMinEngineMaxSound());
    //    }

    //}

    //public void StopPlayEngineMaxSound()
    //{
    //    if (_playEngineMaxSound != null)
    //    {
    //        StopCoroutine(_playEngineMaxSound);
    //        _playEngineMaxSound = null;
    //    }
    //}
}
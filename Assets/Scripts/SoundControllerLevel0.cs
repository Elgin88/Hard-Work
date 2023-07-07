using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SoundControllerLevel0 : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (_audio.isPlaying == false)
        {
            _audio.Play();
        }
    }
}

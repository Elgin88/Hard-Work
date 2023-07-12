using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SoundControllerLevel0 : MonoBehaviour
{
    private AudioSource _audio;

    private IEnumerator Start()
    {
        _audio = GetComponent<AudioSource>();

        while (true)
        {
            if (_audio.isPlaying == false)
            {
                _audio.Play();
            }
            else
            {
                break;
            }
        }

        yield return null;
    }
}

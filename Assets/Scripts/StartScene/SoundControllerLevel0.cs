using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundControllerLevel0 : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private void Update()
    {
        if (_audio.isPlaying == false)
        {
            _audio.Play();
        }        
    }
}
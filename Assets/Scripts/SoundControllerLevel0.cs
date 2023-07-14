using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundControllerLevel0 : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _audio.Play();
    }

    private void OnDisable()
    {
        _audio.Stop();
    }
}
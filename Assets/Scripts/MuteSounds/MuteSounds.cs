using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava;
using Agava.YandexGames;
using UnityEngine.Audio;
using AOT;
using System;

public class MuteSounds : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private int _startValue = 0;
    private int _targetValue = -80;

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL

        if (VideoAd.IsVideoAdOpen)
        {
            _audioMixer.SetFloat("Master", _targetValue);
            //Time.timeScale = 0;
        }
        else
        {
            _audioMixer.SetFloat("Master", _startValue);
            //Time.timeScale = 1;
        }
#endif
    }
}
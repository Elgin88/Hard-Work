using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CanvasSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _buySound;

    public void PlayBuySound()
    {
        _buySound.Play();
    }
}

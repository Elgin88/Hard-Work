using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _engineMinSound;
    [SerializeField] private AudioSource _engineMaxSound;

    private Coroutine _playEngineMinSound;
    private Coroutine _playEngineMaxSound;
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private IEnumerator PlayEngineMinSound()
    {
        while (true)
        {
            yield return null;
        }        
    }

    private IEnumerator PlayMinEngineMaxSound()
    {
        while (true)
        {
            yield return null;
        }        
    }

    public void StartPlayEngineMinSound()
    {
        if (_playEngineMinSound == null)
        {
            _playEngineMinSound = StartCoroutine(PlayEngineMinSound());
        }
    }

    public void StopPlayEngineMinSound()
    {
        if (_playEngineMinSound != null)
        {
            StopCoroutine(_playEngineMinSound);
            _playEngineMinSound = null;
        }
    }

    public void StartPlayEngineMaxSound()
    {
        if (_playEngineMaxSound == null)
        {
            _playEngineMaxSound = StartCoroutine(PlayMinEngineMaxSound());
        }

    }

    public void StopPlayEngineMaxSound()
    {
        if (_playEngineMaxSound != null)
        {
            StopCoroutine(_playEngineMaxSound);
            _playEngineMaxSound = null;
        }
    }
}
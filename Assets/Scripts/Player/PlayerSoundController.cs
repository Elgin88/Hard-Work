using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _engineMinSound;
    [SerializeField] private AudioSource _engineMaxSound;
    [SerializeField] private AudioSource _blockFly;
    [SerializeField] private AudioSource _blockSetPlace;
    [SerializeField] private AudioSource _blockFlyToCollector;
    [SerializeField] private AudioSource _blockPlaceInCollector;
    [SerializeField] private AudioSource _sectionDestractionSound;
    [SerializeField] private AudioSource _blockHitBamperSound;

    public AudioSource BlockFly => _blockFly;
    public AudioSource BlockSetOnCar => _blockSetPlace;
    public AudioSource BlockFlyToCollerctor => _blockFlyToCollector;
    public AudioSource BlockPlaceInCollector => _blockPlaceInCollector;
    public AudioSource SectionDestractionSound => _sectionDestractionSound;
    public AudioSource BlockHitBamperSound => _blockHitBamperSound;

    public void PlayBlockHitBumberSound()
    {
        if (_blockHitBamperSound.isPlaying == false)
        {
            _blockHitBamperSound.Play();
        }
    }


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

    public void PlayObjectDestractionSound()
    {
        if (_sectionDestractionSound.isPlaying == false)
        {
            _sectionDestractionSound.Play();
        }
    }

    public void StopMinEngineSound()
    {
        _engineMinSound.Stop();
    }

    public void StopMaxEngineSound()
    {
        _engineMaxSound.Stop();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]

public class BlockSoundController : MonoBehaviour
{
    private Player _player;
    private AudioSource _audioSourseBlockFlyOnCar;
    private AudioSource _audioSourseBlockSetOnCar;
    private AudioSource _ausioSourseBlockFlyToCollector;
    private AudioSource _audioSourseBlockPlaceInCollector;

    public void InitSoundController(Player player)
    {
        _player = player;

        _audioSourseBlockFlyOnCar = _player.SoundController.BlockFly;
        _audioSourseBlockSetOnCar = _player.SoundController.BlockSetOnCar;
        _ausioSourseBlockFlyToCollector = _player.SoundController.BlockFlyToCollerctor;
        _audioSourseBlockPlaceInCollector = _player.SoundController.BlockPlaceInCollector;
    }

    public void PlayFlyOnCarSFX()
    {
        if (_audioSourseBlockFlyOnCar.isPlaying == false)
        {
            _audioSourseBlockFlyOnCar.Play();
        }        
    }

    public void PlayPlaceOnCarSFX()
    {
        if (_audioSourseBlockSetOnCar.isPlaying == false)
        {
            _audioSourseBlockSetOnCar.Play();
        }        
    }

    public void PlayFlyOnCollectorSFX()
    {
        if (_ausioSourseBlockFlyToCollector.isPlaying == false)
        {
            _ausioSourseBlockFlyToCollector.Play();
        }
    }

    public void PlayBlockPlaceInCollector()
    {
        if (_audioSourseBlockPlaceInCollector.isPlaying==false)
        {
            _audioSourseBlockPlaceInCollector.Play();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]

public class BlockSoundController : MonoBehaviour
{
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    public void PlayFlyOnCarSFX()
    {
        _player.SoundController.BlockFly.Play();
    }

    public void StopFlyOnCarSFX()
    {
        _player.SoundController.BlockFly.Stop();
    }

    public void PlayPlaceOnCarSFX()
    {
        _player.SoundController.BlockSetPlace.Play();
    }

    public void StopPlaceOnCarSFX()
    {
        _player.SoundController.BlockSetPlace.Stop();
    }
}
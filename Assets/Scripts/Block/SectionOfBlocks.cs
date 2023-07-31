using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;

    private int _numberOfBlocks;
    private Player _player;

    public int NumberOfBlocks => _blocks.Length;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _player = destroyer.Player;

            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);                
                block.Init(_player);
            }

            _player.SoundController.PlayObjectDestractionSound();

            gameObject.SetActive(false);
        }
    }

}
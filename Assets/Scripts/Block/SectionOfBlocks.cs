using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;

    private int _numberOfBlocks;

    public int NumberOfBlocks => _blocks.Length;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);
                block.Init(destroyer.Player);
            }

            gameObject.SetActive(false);
        }
    }

}
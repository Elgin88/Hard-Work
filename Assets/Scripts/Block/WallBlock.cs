using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    private Block[] _blocks;
    private Wall _wall;

    private void Start()
    {
        _blocks = GetComponentsInChildren<Block>();
        _wall = GetComponentInChildren <Wall>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Destroy(_wall.gameObject);

            for (int i = 0; i < _blocks.Length; i++)
            {
                _blocks[i].gameObject.SetActive(true);
            }
        }
    }
}

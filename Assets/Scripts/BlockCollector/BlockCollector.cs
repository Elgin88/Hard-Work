using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollector : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }
}
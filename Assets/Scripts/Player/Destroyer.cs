using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Player _player;

    public Player Player => _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
    }
}

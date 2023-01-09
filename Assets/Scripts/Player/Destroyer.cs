using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private BlockGiver _blockGiver;
    private Player _player;

    public Player Player => _player;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        _blockGiver = GetComponentInParent<Player>().GetComponentInChildren<Inventory>().GetComponent<BlockGiver>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<ParkingArea>(out ParkingArea parkingArea))
        {
            _blockGiver.StartCoroutineGiveBlock();
        }
    }
}

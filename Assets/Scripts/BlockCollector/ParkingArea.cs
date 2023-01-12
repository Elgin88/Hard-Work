using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _inventory.UnloadBlocks();
        }        
    }
}

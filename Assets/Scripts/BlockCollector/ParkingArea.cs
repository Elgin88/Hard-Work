using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponent<Inventory>();
        Debug.Log("ЗДЕСЬ!!! Надо сделать, чтобы работал Триггер при пересечении игрока и площадки");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("Надо сделать, чтобы работал Триггер");
            _inventory.UnloadBlocks();
        }        
    }
}

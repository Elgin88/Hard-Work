using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    private Inventory _inventory;
    private CollectionPoint _collectionPoint;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponentInChildren<Inventory>();
        _collectionPoint = GetComponentInParent<BlockCollector>().GetComponentInChildren<CollectionPoint>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _inventory.StartCoroutineUnloadBlocks(_collectionPoint.transform.position);
        }        
    }
}

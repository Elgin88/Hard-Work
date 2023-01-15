using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    private CollectionPoint _collectionPoint;
    private UnloaderBlocks _unloaderBlocks;
    private Inventory _inventory;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _inventory = _player.GetComponentInChildren<Inventory>();
        _unloaderBlocks = _player.GetComponentInChildren<UnloaderBlocks>();
        _collectionPoint = GetComponentInParent<BlockCollector>().GetComponentInChildren<CollectionPoint>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            if (_inventory.GetLastBlock() != null)
            {
                Debug.Log("Запуск корутины на разгрузку блока в " + this.name);
                _unloaderBlocks.StartCoroutineUploadBlocks(_collectionPoint.transform.position);
            }           
        }        
    }
}

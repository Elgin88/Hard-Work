using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody))]

public class CollectionParkingArea : MonoBehaviour
{
    private Unloader _unloader;
    private Player _player;

    private void Start()
    {
        _unloader = FindObjectOfType<Unloader>();
        _player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer) & _player.IsUpload == false & _player.IsUnload == false)
        {
            _player.IsMoveToCollector(true);
            _player.IsMoveToPlayer(false);
            _unloader.StartUnload();
        }        
    }
}

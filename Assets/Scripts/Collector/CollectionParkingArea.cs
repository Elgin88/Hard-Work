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
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer) & _player.IsUpload == false)
        {
            _player.SetStatusUnload(true);
            _player.SetStatusUpload(false);
            _unloader.StartUnload();
        }        
    }
}

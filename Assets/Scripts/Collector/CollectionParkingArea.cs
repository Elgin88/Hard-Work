using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CollectionParkingArea : MonoBehaviour
{
    private Unloader _unloader;
    private Player _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _unloader = FindObjectOfType<Unloader>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _unloader.StartUnload();
        }        
    }
}

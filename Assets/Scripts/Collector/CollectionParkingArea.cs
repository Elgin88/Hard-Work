using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CollectionParkingArea : MonoBehaviour
{
    private Unloader _unloader;
    private Player _player;
    private GameRequireComponents _gameRequireComponents;

    private void OnEnable()
    {
        _gameRequireComponents = FindObjectOfType<GameRequireComponents>();

        _player = _gameRequireComponents.Player;
        _unloader = _gameRequireComponents.Unloader;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _unloader.StartUnload();
        }        
    }
}

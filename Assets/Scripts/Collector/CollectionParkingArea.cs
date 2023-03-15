using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CollectionParkingArea : MonoBehaviour
{
    [SerializeField] private Unloader _unloader;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        if (_unloader == null || _player ==null)
        {
            Debug.Log("No SerialzieField in " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer) & _player.LoadController.IsUpload == false)
        {
            _unloader.StartUnload();
        }        
    }
}

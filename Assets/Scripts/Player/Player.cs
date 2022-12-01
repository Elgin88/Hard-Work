using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _higth;

    private Rigidbody _rigidbody;
    private Vector3 _currentDuraction;
    private PlayerController _playerController;

    public Rigidbody Rigidbody => _rigidbody;
    public Vector3 CurrentDuraction => _currentDuraction;

    private void Start()
    {
        if (_higth == 0)        
            Debug.Log("Player no SerializeField");        

        _rigidbody = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    public Vector3 GetCurrentDirection()
    {
        return _playerController.CurrentDirection;
    }
}

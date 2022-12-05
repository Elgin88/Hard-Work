using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _higth;

    private Vector3 _currentDuraction;
    private PlayerController _playerController;

    public Vector3 CurrentDuraction => _currentDuraction;

    private void Start()
    {
        if (_higth == 0)        
            Debug.Log("Player no SerializeField");

        _playerController = GetComponent<PlayerController>();
    }

    public Vector3 GetCurrentDirection()
    {
        return _playerController.CurrentDirection;
    }
}

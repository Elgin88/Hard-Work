using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _higth;

    private Vector3 _currentDuraction;
    private PlayerMover _playerController;
    private float _startPositionY;

    public Vector3 CurrentDuraction => _currentDuraction;

    private void Start()
    {
        if (_higth == 0)        
            Debug.Log("In Player no SerializeField");

        _playerController = GetComponent<PlayerMover>();
        _startPositionY = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _startPositionY, transform.position.z);
    }

    public Vector3 GetCurrentDirection()
    {
        return _playerController.CurrentDirection;
    }
}

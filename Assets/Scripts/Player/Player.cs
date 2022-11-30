using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _higth;

    private Rigidbody _rigidbody;
    private Vector3 _currentDuraction;

    public Rigidbody Rigidbody => _rigidbody;
    public Vector3 CurrentDuraction => _currentDuraction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}

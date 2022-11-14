using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _changeUpSpeed;
    [SerializeField] private float _changeDownSpeed;

    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;
    public float ChangeUpSpeed => _changeUpSpeed;
    public float ChangeDownSpeed => _changeDownSpeed;
}

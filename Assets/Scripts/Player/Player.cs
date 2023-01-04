using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class Player : MonoBehaviour
{
    private PlayerMover _playerController;
    private float _startPositionY;

    public event UnityAction IsPushed;

    private void Start()
    {
        _playerController = GetComponent<PlayerMover>();
        _startPositionY = transform.position.y;
    }

    public void Push()
    {
        IsPushed.Invoke();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _startPositionY, transform.position.z);
    }

    public Quaternion GetCurrentDirection()
    {
        return _playerController.CurrentPlayerDirection;
    }
}

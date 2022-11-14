using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float _deltaX;
    private float _deltaY;
    private float _deltaZ;

    private PlayerController _playerController;
    private Coroutine _moveWork = null;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        _deltaX = _playerController.transform.position.x - transform.position.x;
        _deltaX = _playerController.transform.position.y - transform.position.y;
        _deltaX = _playerController.transform.position.z - transform.position.z;

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = new Vector3(_playerController.transform.position.x - _deltaX,
                _playerController.transform.position.y + _deltaY, _playerController.transform.position.z + _deltaZ);

            yield return null;
        }
    }

    public void StartCoroutineMove()
    {
        if (_moveWork == null)
        {
            _moveWork = StartCoroutine(Move());
        }
    }

    public void StopCoroutineMove()
    {
        if (_moveWork != null)
        {
            StopCoroutine(_moveWork);
            _moveWork = null;
        }
    }
}

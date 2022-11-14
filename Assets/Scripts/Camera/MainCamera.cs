using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private float _deltaX;
    [SerializeField] private float _deltaY;
    [SerializeField] private float _deltaZ;

    private PlayerController _playerController;
    private Coroutine _moveWork = null;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = new Vector3(_playerController.transform.position.x,
                _playerController.transform.position.y - _deltaY, _playerController.transform.position.z + _deltaZ);

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

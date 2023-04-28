using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private float _deltaY = 10;
    private float _deltaZ = -9;
    private float _speedChangeX = 4f;
    private float _speedChangeZ = 4f;
    private float _deltaRotationX = 0.3f;
    private PlayerMover _player;
    private Coroutine _moveWork = null;
    private float _currentCameraPositionX;
    private float _currentCameraPositionY;
    private float _currentCameraPositionZ;
    private float _currentCameraRotationX;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMover>();

        _currentCameraPositionX = _player.transform.position.x;
        _currentCameraPositionY = _player.transform.position.y + _deltaY;
        _currentCameraPositionZ = _player.transform.position.z + _deltaZ;

        transform.rotation = new Quaternion(_deltaRotationX, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _currentCameraPositionX = Mathf.MoveTowards(_currentCameraPositionX, _player.transform.position.x, _speedChangeX * Time.deltaTime);

            _currentCameraPositionZ = Mathf.MoveTowards(_currentCameraPositionZ, _player.transform.position.z + _deltaZ, _speedChangeZ * Time.deltaTime);

            transform.position = new Vector3(_currentCameraPositionX, _currentCameraPositionY, _currentCameraPositionZ);     

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

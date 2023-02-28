using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CalculatorBlocks))]
[RequireComponent(typeof(EnderLevel))]
[RequireComponent(typeof(ChooserMedals))]

public class MainCamera : MonoBehaviour
{
    [SerializeField] private float _deltaX;
    [SerializeField] private float _deltaY;
    [SerializeField] private float _deltaZ;
    [SerializeField] private float _speedChangeX;
    [SerializeField] private float _speedChangeY;
    [SerializeField] private float _speedChangeZ;

    private PlayerMover _player;
    private Coroutine _moveWork = null;
    private float _currentCameraPositionX;
    private float _currentCameraPositionY;
    private float _currentCameraPositionZ;

    private void Start()
    {
        if (_deltaX == 0 || _deltaY == 0 || _deltaZ == 0 || _speedChangeX == 0 || _speedChangeY == 0 || _speedChangeZ == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        _player = FindObjectOfType<PlayerMover>();
        _currentCameraPositionX = _player.transform.position.x;
        _currentCameraPositionY = _player.transform.position.y - _deltaY;
        _currentCameraPositionZ = _player.transform.position.z + _deltaZ;
        StartCoroutineMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _currentCameraPositionX = Mathf.MoveTowards(_currentCameraPositionX, _player.transform.position.x, _speedChangeX * Time.deltaTime);
            _currentCameraPositionY = Mathf.MoveTowards(_currentCameraPositionY, _player.transform.position.y - _deltaY, _speedChangeY * Time.deltaTime);
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

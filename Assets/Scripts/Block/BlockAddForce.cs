using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BlockAddForce : MonoBehaviour
{
    [SerializeField] private float _minTimeWakeUp;
    [SerializeField] private float _maxTimeWakeUp;
    [SerializeField] private float _minY;
    [SerializeField] private float _force;

    private WaitForSeconds _timeWakeUp;
    private Coroutine _addForceCoroutine;
    private Rigidbody _rigidbody;
    private float _time;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _timeWakeUp = new WaitForSeconds(_time);

        _time = Random.Range(_minTimeWakeUp, _maxTimeWakeUp);

        StartCoroutineAddForce();
    }

    private IEnumerator AddForce()
    {
        while (true)
        {
            if (transform.position.y > _minY)
            {
                _rigidbody.AddForce(new Vector3(0, _force, 0));
            }

            yield return _timeWakeUp;
        }
    }

    private void StartCoroutineAddForce()
    {
        if (_addForceCoroutine == null)
        {
            _addForceCoroutine = StartCoroutine(AddForce());
        }
    }

    private void StopCoroutineAddForce()
    {
        if (_addForceCoroutine != null)
        {
            StopCoroutine(_addForceCoroutine);
            _addForceCoroutine = null;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerDestroyerTakeDamagePoint : MonoBehaviour
{
    private ParticleSystem _particle;
    private SphereCollider _collider;
    private WaitForSeconds _pauseWFS;
    private Coroutine _pause;

    private void Start()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
        _collider = GetComponent<SphereCollider>();

        _pauseWFS = new WaitForSeconds(_particle.main.duration * 0.98f);

        _particle.Pause();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block))
        {
            _particle.Play();

            StartSetPause();
        }
    }

    private IEnumerator SetPause()
    {
        while (true)
        {
            yield return _pauseWFS;

            _particle.Pause();

            StopSetPause();
        }
    }

    private void StartSetPause()
    {
        if (_pause == null)
        {
            _pause = StartCoroutine(SetPause());
        }
    }

    private void StopSetPause()
    {
        if (_pause != null)
        {
            StopCoroutine(_pause);
            _pause = null;
        }
    }
}
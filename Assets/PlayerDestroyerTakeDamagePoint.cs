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
    private WaitForSeconds _pauseWFS;
    private Coroutine _pause;

    private void OnEnable()
    {
        _particle = GetComponentInChildren<ParticleSystem>();

        _particle.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block) || collision.gameObject.TryGetComponent<SectionOfBlocks>(out SectionOfBlocks section))
        {
            _particle.gameObject.SetActive(true);
            _particle.Play();
        }
    }    
}
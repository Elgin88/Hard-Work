using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EndLevelButtonFlasher : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }

        _animator.StartPlayback();

    }

    private void Update()
    {
        _animator.StartPlayback();
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private bool _isTaken = false;

    public bool IsTaken => _isTaken;

    public void TakePoint()
    {
        _isTaken = true;
    }

    public Vector3 FindCurrentPosition()
    {
        return transform.position;
    }
}

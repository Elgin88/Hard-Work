using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointFixer : MonoBehaviour
{
    private Transform _playerTransform;

    private float _deltaX;
    private float _deltaY;
    private float _deltaZ;

    private void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
        
    }

    private IEnumerator FixPosition()
    {
        while (true)
        {
            yield return null;
        }
    }

}

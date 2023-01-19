using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollector : MonoBehaviour
{
    private Player _player;
    private bool _isWork = false;

    public bool IsWork => _isWork;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    public void SetIsWorkTrue()
    {
        _isWork = false;
    }

    public void SetIsWorkFalse()
    {
        _isWork = true;
    }
}
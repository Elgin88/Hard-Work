using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]

public class BlockFixer : MonoBehaviour
{
    private Coroutine _fixBlock;
    private Player _player;
    private Block _block;

    private void OnEnable()
    {
        _block = GetComponent<Block>();        
    }

    private IEnumerator FixBlock()
    {
        _player = GetComponent<Block>().Player;

        while (true)
        {
            if (_block.Point != null)
            {
                _block.SetPosition(_block.Point.transform.position.x, _block.Point.transform.position.y, _block.Point.transform.position.z);
                _block.SetQuaternion(_player.GetCurrentDirection());
            }

            yield return null;
        }
    }
    
    public void StartCoroutineFixBlock()
    {
        _block.KinematicOn();

        if (_fixBlock == null)
        {
            _fixBlock = StartCoroutine(FixBlock());
        }
    }

    public void StopCoroutineFixBlock()
    {
        if (_fixBlock != null)
        {
            StopCoroutine(_fixBlock);
            _fixBlock = null;
        }
    }
}

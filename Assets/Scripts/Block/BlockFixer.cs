using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Block))]

public class BlockFixer : MonoBehaviour
{
    private Coroutine _fixBlock = null;
    private Player _player;
    private Block _block;

    private void Start()
    {
        _block = GetComponent<Block>();        
    }

    private IEnumerator FixBlock()
    {
        _player = GetComponent<Block>().Player;

        while (true)
        {
            _block.SetPosition(_block.PointOnPlayer.transform.position.x , _block.PointOnPlayer.transform.position.y, _block.PointOnPlayer.transform.position.z);
            _block.SetQuaternion(_player.GetCurrentDirection());

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

    public void StopCoroutineSetBlock()
    {
        if (_fixBlock != null)
        {
            StopCoroutine(_fixBlock);
            _fixBlock = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class BlockFixer : MonoBehaviour
{
    private Player _player;
    private Coroutine _fixBlock = null;
    private BlockPoint _blockPoint;
    private Block _block;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private IEnumerator FixBlock()
    {
        while (true)
        {
            _block.SetPosition(_blockPoint.transform.position.x , _blockPoint.transform.position.y, _blockPoint.transform.position.z);
            _block.SetQuaternion(_player.transform);

            yield return null;
        }
    }

    public void StartCoroutineFixBlock(Block block, BlockPoint blockPoint)
    {
        _block = block;
        _blockPoint = blockPoint;          

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFixer : MonoBehaviour
{
    private Coroutine _fixBlock = null;
    private Player _player;
    private Point _blockPoint;
    private Block _block;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private IEnumerator FixBlock()
    {
        while (true)
        {
            _block.SetPosition(_blockPoint.transform.position.x , _blockPoint.transform.position.y, _blockPoint.transform.position.z);
            _block.SetQuaternion(_player.GetCurrentDirection());            

            yield return null;
        }
    }

    public void StartCoroutineFixBlock(Block block, Point blockPoint)
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

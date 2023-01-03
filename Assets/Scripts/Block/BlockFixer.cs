using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFixer : MonoBehaviour
{
    private Coroutine _fixBlock = null;
    private Player _player;
    private Block _block;

    private void Start()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
        _block = GetComponent<Block>();
    }

    private IEnumerator FixBlock()
    {
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

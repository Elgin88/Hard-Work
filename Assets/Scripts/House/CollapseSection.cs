using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class CollapseSection : MonoBehaviour
{
    [SerializeField] private Block[] _blocks;

    private LineOfBlocks _lineOfBlocks;

    private void Start()
    {
        _lineOfBlocks = GetComponentInChildren<LineOfBlocks>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _lineOfBlocks.gameObject.SetActive(false);

            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);
            }
        }
    }
}

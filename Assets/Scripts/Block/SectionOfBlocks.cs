using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class SectionOfBlocks : MonoBehaviour
{
    [SerializeField] private Block [] _blocks;

    private Rigidbody _rigidbody;
    private int _numberOfBlocks;

    public int NumberOfBlocks => _numberOfBlocks;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _numberOfBlocks = _blocks.Length;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            foreach (Block block in _blocks)
            {
                block.gameObject.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }

    public int GetCountBlocks()
    {
        return _blocks.Length;
    }
}
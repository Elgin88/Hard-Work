using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockMover))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(BlockFixer))]

public class Block : MonoBehaviour
{
    [SerializeField] private float _delayForTaken = 8;

    private BoxCollider _collider;
    private BlockMover _moverBlock;
    private Inventory _inventory;
    private Rigidbody _rigidbody;
    private Player _player;
    private Point _point;

    public Player Player => _player;
    public Point Point => _point;

    private void Start()
    {
        _inventory = FindObjectOfType<Player>().GetComponentInChildren<Inventory>();
        _moverBlock = GetComponent<BlockMover>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            KinematicOff();
            GravityOn();

            _point = _inventory.TryTakePoin();

            if (_point == null)
            {
                Debug.Log("Нет точки" + Time.time);
            }

            if (_point != null)
            {
                KinematicOn();
                ColliderOff();
                GravityOff();

                _moverBlock.StartCoroutineFlight(_point);
            }
        }
    }

    public void GravityOn()
    {
        _rigidbody.useGravity = true;
    }

    public void GravityOff()
    {
        _rigidbody.useGravity = false;
    }

    public void ColliderOn()
    {
        _collider.enabled = true;
    }

    public void ColliderOff()
    {
        _collider.enabled = false;
    }

    public void KinematicOn()
    {
        _rigidbody.isKinematic = true;
    }

    public void KinematicOff()
    {
        _rigidbody.isKinematic = false;
    }

    public void SetPosition(float x, float y, float z)
    {
        transform.position = new Vector3 (x, y, z);
    }

    public void SetQuaternion(Vector3 currentRotation)
    {
        transform.rotation = Quaternion.LookRotation(currentRotation);
    }
}
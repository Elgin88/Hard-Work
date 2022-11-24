using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerPositionSetter : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}

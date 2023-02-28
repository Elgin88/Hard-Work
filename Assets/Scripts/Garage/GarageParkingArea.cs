using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageParkingArea : MonoBehaviour
{
    [SerializeField] private GarageUI _garageUI;

    private void Start()
    {
        if (_garageUI == null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _garageUI.gameObject.SetActive(true);
        }
    }
}

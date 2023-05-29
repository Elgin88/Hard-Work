using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageParkingArea : MonoBehaviour
{
    private GameRequireComponents _gameRequirecomponents;
    private GarageUI _garageUI;

    private void OnEnable()
    {
        _gameRequirecomponents = FindObjectOfType<GameRequireComponents>();
        _garageUI = _gameRequirecomponents.GarageUI;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _garageUI.gameObject.SetActive(true);
        }
    }
}
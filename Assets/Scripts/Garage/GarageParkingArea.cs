using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageParkingArea : MonoBehaviour
{
    private CanvasUI _canvasUI;
    private GarageUI _garageUI;
    private Garage _garage;

    private void Start()
    {
        _canvasUI = FindObjectOfType<CanvasUI>();
        _garageUI = _canvasUI.GarageUI;
        _garage = FindObjectOfType<Garage>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
        {
            _garageUI.gameObject.SetActive(true);

            if (destroyer.Player.Money >= _garage.FuelCoust)
            {
                foreach (var indicator in _canvasUI.AddFuelIndicators)
                {
                    indicator.gameObject.SetActive(true);
                }
            }            
        }
    }
}
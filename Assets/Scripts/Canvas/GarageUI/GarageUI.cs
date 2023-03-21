using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageUI : MonoBehaviour
{
    [SerializeField] private float _distandeToOffGarage;
    [SerializeField] private DestroyerPoint _destroyerPoint;
    [SerializeField] private GarageParkingArea _garageParkingArea;
    [SerializeField] private GarageUI _garageUI;

    private Coroutine _checkDistance;

    private void OnEnable()
    {
        StartCheckDistance();
    }

    private void OnDisable()
    {
        StopCheckDistance();
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            if (Vector3.Distance(_destroyerPoint.transform.position, _garageParkingArea.transform.position) > _distandeToOffGarage)
            {
                _garageUI.gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void StartCheckDistance()
    {
        if (_checkDistance == null)
        {
            _checkDistance = StartCoroutine(CheckDistance());
        }
    }

    private void StopCheckDistance()
    {
        if (_checkDistance != null)
        {
            StopCoroutine(_checkDistance);
            _checkDistance = null;
        }
    }
}

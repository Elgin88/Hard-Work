using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageUI : MonoBehaviour
{
    [SerializeField] private float _rangeToClosePanel;

    private DestroyerPoint _destroyerPoint;
    private GarageParkingArea _garageParkingArea;
    private GarageUI _garageUI;
    private Coroutine _checkDistance;

    private void OnEnable()
    {
        if (_destroyerPoint == null)
        {
            _destroyerPoint = FindObjectOfType<DestroyerPoint>();
            _garageParkingArea = FindObjectOfType<GarageParkingArea>();
            _garageUI = FindObjectOfType<GarageUI>();                
        }

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
            if (Vector3.Distance(_destroyerPoint.transform.position, _garageParkingArea.transform.position) > _rangeToClosePanel)
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

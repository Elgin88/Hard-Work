using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageUI : MonoBehaviour
{
    [SerializeField] private float _distanceToDisablePanel;
    [SerializeField] private GarageParkingArea _garageParkingArea;
    [SerializeField] private Destroyer _destroyer;

    private Coroutine _controlDistance;

    private void Start()
    {
        if (_distanceToDisablePanel == 0|| _garageParkingArea==null)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        StartControlDistance();        
    }

    private void OnDisable()
    {
        StopControlDistance();
    }

    private IEnumerator ControlDistance()
    {
        while (true)
        {
            if (Vector3.Distance(_destroyer.transform.position, _garageParkingArea.transform.position) > _distanceToDisablePanel)
            {
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    public void StartControlDistance()
    {
        if (_controlDistance == null)
        {
            _controlDistance = StartCoroutine(ControlDistance());
        }
    }

    public void StopControlDistance()
    {
        if (_controlDistance != null)
        {
            StopCoroutine(_controlDistance);
            _controlDistance = null;
        }
    }
}

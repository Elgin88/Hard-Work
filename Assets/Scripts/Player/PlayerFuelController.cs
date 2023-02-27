using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFuelController : MonoBehaviour
{
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _deltaFuel;

    private float _currentFuel;
    private bool _isFuelLoss;
    private Coroutine _burnFuel;
    private PlayerSpeedSetter _speedSetter;

    public bool IsFuelLoss => _isFuelLoss;

    public event UnityAction <float, float> IsFuelChanged;

    private void Start()
    {
        if (_maxFuel == 0)
        {
            Debug.Log("No SerializeField in " + gameObject.name);
        }

        if (_speedSetter == null)
        {
            _speedSetter = FindObjectOfType<PlayerSpeedSetter>();
        }

        _currentFuel = _maxFuel;

        StartBurnFuel();        
    }

    private IEnumerator LessFuel()
    {
        while (true)
        {
            _currentFuel -= _speedSetter.CurrentSpeed * _deltaFuel * Time.deltaTime;
            IsFuelChanged.Invoke(_currentFuel, _maxFuel);

            if (_currentFuel < 0)
            {
                _isFuelLoss = true;
                StopBurnFuel();
            }

            yield return null;
        }
    }

    private void StartBurnFuel()
    {
        if (_burnFuel == null)
        {
            _burnFuel = StartCoroutine(LessFuel());
        }
    }

    private void StopBurnFuel()
    {
        if (_burnFuel != null)
        {
            StopCoroutine(_burnFuel);
            _burnFuel = null;
        }
    }
}

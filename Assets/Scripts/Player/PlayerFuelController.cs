using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFuelController : MonoBehaviour
{
    [SerializeField] private float _maxFuel;

    private float _currentFuel;
    private bool _isFuelLoss;
    private Coroutine _removeFuel;

    public bool IsFuelLoss => _isFuelLoss;

    public event UnityAction <float, float> IsFuelChanged;

    private IEnumerator RemoveFuel()
    {
        while (true)
        {
            yield return null;
        }
    }
}

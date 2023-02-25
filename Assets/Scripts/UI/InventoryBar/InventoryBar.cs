using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class InventoryBar : MonoBehaviour
{
    private Slider _slider;
    private TMP_Text _max;
    private TMP_Text _middle;
    private TMP_Text _min;
    private Inventory _inventory;

    private void Start()
    {
        _slider.value = 0;

    }

    private void OnEnable()
    {
        if (_slider == null|| _max == null || _middle == null || _min == null )
        {
            _slider = GetComponent<Slider>();
            _max = GetComponentInChildren<InventoryBarMax>().GetComponent<TMP_Text>();
            _middle = GetComponentInChildren<InventoryBarMiddle>().GetComponent<TMP_Text>();
            _min = GetComponentInChildren<InventoryBarMin>().GetComponent<TMP_Text>();
        }               
    }

    private void OnDisable()
    {
        
    }

}

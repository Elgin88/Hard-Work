using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempText : MonoBehaviour
{
    [SerializeField]private TMP_Text _text;
    [SerializeField] private Loader _loader;

    public void Update()
    {
        _text.text = _loader.GetSavedDataLevelName();
    }
}

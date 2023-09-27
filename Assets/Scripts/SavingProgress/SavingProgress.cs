using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava;

public class SavingProgress : MonoBehaviour
{
    public void SaveProgress()
    {
        Agava.YandexGames.PlayerPrefs.Save();
    }
}
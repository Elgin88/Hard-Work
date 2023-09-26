using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.WebUtility;
using Agava.YandexGames;

public class MaximizedWindowChecker : MonoBehaviour
{
    private void FixedUpdate()
    {
#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
        if (WebApplication.InBackground)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
#endif
    }
}
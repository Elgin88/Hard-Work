using System;
using System.Collections;
using Agava.WebUtility;
using Agava.YandexGames;
using UnityEngine;

public class StarterSDK : MonoBehaviour
{
    private IEnumerator Start()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if UNITY_WEBGL
        yield return YandexGamesSdk.Initialize();
#endif
    }
}

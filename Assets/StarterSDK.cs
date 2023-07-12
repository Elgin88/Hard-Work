using System.Collections;
using Agava.YandexGames;
using UnityEngine;

public class StarterSDK : MonoBehaviour
{
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();
    }
}

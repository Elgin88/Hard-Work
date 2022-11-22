using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneButton : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene");
    }
}

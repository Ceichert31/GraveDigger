using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public delegate void OnSceneLoaded(int scene);
    public static OnSceneLoaded loadScene;
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void OnEnable()
    {
        loadScene += LoadLevel;
    }
    private void OnDisable()
    {
        loadScene -= LoadLevel;
    }
}

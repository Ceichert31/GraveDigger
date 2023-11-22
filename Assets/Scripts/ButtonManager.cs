using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Load(int scene)
    {
        SceneLoader.loadScene(scene);
    }
}

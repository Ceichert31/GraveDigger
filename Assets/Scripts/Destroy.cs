using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    /// <summary>
    /// Called by Animator
    /// </summary>
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVIncrease : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
            cam.fieldOfView += (Time.deltaTime * 2);
            if (cam.fieldOfView >= 85)
                enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBasedFOV : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody rb;
    private Camera cam;

    [Header("Field of View")]
    [SerializeField] private float scaleFOV = 10.0f;
    [SerializeField] private float minFOV = 80.0f;
    [SerializeField] private float maxFOV = 120.0f;

    private float viewVelocity;
    private float targetView;

    private float _additions;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        float raw = rb.velocity.magnitude;
        float scaled = raw / scaleFOV;
        if (scaled < 0.01f) scaled = 0f;

        targetView = minFOV + scaled;
        //float time = 0.3f;
        if (targetView > maxFOV) targetView = maxFOV;

        cam.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, targetView + _additions, ref viewVelocity, 0.2f);
    }
    /// <summary>
    /// Increases FOV and slowly decreases it
    /// </summary>
    /// <param name="fov"></param>
    /// <param name="time"></param>
    public void AddFOV(float fov, float time)
    {
        _additions = fov;
        StartCoroutine(RemoveFOV(fov, time));
    }

    private IEnumerator RemoveFOV(float fov, float time)
    {
        yield return new WaitForSeconds(time);
        _additions -= fov;
    }
}

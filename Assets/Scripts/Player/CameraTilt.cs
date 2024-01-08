using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    [Header("Tilt Refrences")]
    [SerializeField] private Transform target;
    private InputManager inputManager;
    private Rigidbody rb;

    [Header("Tilt Settings")]
    [SerializeField] private float tiltInSpeed = 10;
    [SerializeField] private float tiltOutSpeed = 9;
    [SerializeField] private float tiltAmount = -4;

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        if (inputManager._isUp)
            return;

        TiltUpdate();
    }
    void TiltUpdate()
    {
        bool doTilt = false;

        if (!inputManager._isGrounded)
            return;

        if (inputManager.moveInput.x != 0 && rb.velocity.magnitude > 2)
            doTilt = true;

        if (doTilt)
        {
            if (inputManager.moveInput.x < 0)
                currentRotation = new Vector3(0, 0, -tiltAmount);
            else
                currentRotation = new Vector3(0, 0, tiltAmount);
        }

        //Return to Origin
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, tiltOutSpeed * Time.deltaTime);

        //Rotate to target
        targetRotation = Vector3.Lerp(targetRotation, currentRotation, tiltInSpeed * Time.deltaTime);
        target.transform.localRotation = Quaternion.Euler(targetRotation);
    }
}

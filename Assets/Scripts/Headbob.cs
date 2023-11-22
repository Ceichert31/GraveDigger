using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    [Header("Headbob Refrences")]
    [SerializeField] private Transform target;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody rb;

    [Header("Headbob Variables")]
    [SerializeField] private Vector2 bobSpeed;
    [SerializeField] private Vector2 bobIntensity;
    [SerializeField] private AnimationCurve bobCurveX;
    [SerializeField] private AnimationCurve bobCurveY;

    private Vector2 currentPosition;
    private Vector2 currentTime;
    private Vector3 velocity;

    private float smoothTime;

    private void Start()
    {

    }
    private void Update()
    {
        HeadbobUpdate();
    }
    void HeadbobUpdate()
    {
        float speedFactor = 0;
        if (rb != null)
            speedFactor = rb.velocity.magnitude;

        if (!inputManager._isGrounded || !inputManager._isMoving || rb.velocity.magnitude < 2f)
        {
            currentPosition = Vector2.zero;
            currentTime = Vector2.zero;
            smoothTime = 0.2f;
        }
        else if (inputManager._isMoving)
        {
            currentTime.x += bobSpeed.x / 10 * Time.deltaTime * speedFactor;
            currentTime.y += bobSpeed.y / 10 * Time.deltaTime * speedFactor;
            
            currentPosition.x = bobCurveX.Evaluate(currentTime.x) * bobIntensity.x;
            currentPosition.y = bobCurveY.Evaluate(currentTime.y) * bobIntensity.y;

            smoothTime = 0.1f;
        }
    }
    private void FixedUpdate()
    {
        Vector3 targetPosition = new(currentPosition.x, currentPosition.y, 0);
        Vector3 desiredPosition = Vector3.SmoothDamp(target.localPosition, targetPosition, ref velocity, smoothTime);

        target.localPosition = desiredPosition;
    }
}

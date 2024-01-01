using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _affector;
    [SerializeField] private Vector2 _yClamp;
    [SerializeField, Range(0.001f, 20f)] private float _speed = 0.15f;

    [SerializeField] private bool invertY;

    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        if (Camera.main == null) return;

        // Get the desired direction
        Vector3 dir = Camera.main.transform.position - transform.position;

        // Clamp the rotation
        dir.y = Mathf.Clamp(dir.y, _yClamp.x, _yClamp.y);
        
        // Store the direction
        Quaternion lookDir = Quaternion.LookRotation(-dir);

        // Step through
        float step = _speed * 10.0f * Time.deltaTime;
        _affector.transform.rotation = Quaternion.Slerp(_affector.transform.rotation, lookDir, step);
    }
}
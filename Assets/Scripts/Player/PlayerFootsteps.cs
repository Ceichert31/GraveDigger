using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private InputManager movement;
    private Rigidbody rb;

    [SerializeField] private AudioClip[] footsteps;
    private AudioSource source;
    [SerializeField] private float minPitch = 0.95f;
    [SerializeField] private float maxPitch = 1.1f;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _interval = 0.1f;

    float currentTime = 0.0f;

    private void Awake()
    {
        movement = GetComponent<InputManager>();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //float speedFactor = rb.velocity.magnitude;

        if(!movement._isGrounded || !movement._isMoving || rb.velocity.magnitude < 2.0f)
        {
            currentTime = 0.0f;
        } 
        else if (movement._isMoving) {
            currentTime += _speed / 10 * Time.deltaTime;

            if(currentTime > _interval)
            {
                currentTime = 0.0f;

                source.pitch = Random.Range(minPitch, maxPitch);
                
                int index = Random.Range(0, footsteps.Length);
                AudioClip clip = footsteps[index];
                source.PlayOneShot(clip);
            }
        }
    }
}


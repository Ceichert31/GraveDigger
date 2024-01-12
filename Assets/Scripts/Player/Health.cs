using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int health = 3;

    private bool damageDelay;

    private float waitTime;

    private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        animator.SetInteger("Health", health);
        if (health <= 0)
            SceneLoader.loadScene(0);

        //Health Regen
        if (health < 3)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 10)
            {
                health++;
                waitTime = 0;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (damageDelay)
            return;

        if (other.gameObject.layer == 9)
        {
            source.PlayOneShot(clip);
            health--;
            waitTime = 0;
            damageDelay = true;
            Invoke(nameof(DamageReset), 1);
        }
            
    }

    private void DamageReset() => damageDelay = false;

}

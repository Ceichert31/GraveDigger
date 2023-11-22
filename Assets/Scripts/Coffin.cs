using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    private Grave grave;

    private ParticleSystem particle;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
        grave = GetComponentInParent<Grave>();
    }
    public void DugUp()
    {
        animator.enabled = true;
    }
    /// <summary>
    /// Called by Animator
    /// </summary>
    void PlayParticle()
    {
        particle.Play();
    }
    /// <summary>
    /// Called by Animator
    /// </summary>
    void SinkGrave()
    {
        gameObject.layer = 7;
        grave.Sink();
    }
}

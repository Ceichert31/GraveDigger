using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    private Coffin coffin;
    private bool isDug;
    public string text = "[E] Dig";
    [SerializeField] private string emptyText = "Empty";

    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    private void Awake()
    {
        coffin = GetComponentInChildren<Coffin>();
        audioSource = GetComponent<AudioSource>();
    }
    public void StartAnimation()
    {
        if (isDug)
            return;

        isDug = true;
        coffin.DugUp();
        audioSource.PlayOneShot(clip, 1);

        text = emptyText;
    }
    public void Sink()
    {
        audioSource.Play();
        animator.enabled = true;
    }
}

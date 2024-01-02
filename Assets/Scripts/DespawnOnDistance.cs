using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnDistance : MonoBehaviour
{
    [Header("LOD Settings")]
    private Transform location;
    [SerializeField] private float loadDistance;
    private GameObject child;
    private void Start()
    {
        location = GameManager.Instance.player;
        child = GetComponentInChildren<Billboard>().gameObject;
    }
    private void Update()
    {
        //Check if the player is further than the load distance
        if (Vector3.Distance(transform.position, location.position) > loadDistance)
            child.SetActive(false);
        else
            child.SetActive(true);
    }
}

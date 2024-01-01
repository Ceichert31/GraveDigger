using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOnDistance : MonoBehaviour
{
    private Transform location;
    [SerializeField] private float loadDistance;
    private GameObject child;
    private void Awake()
    {
        location = GameManager.findPlayer.Invoke();
        child = GetComponentInChildren<GameObject>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, location.position) > loadDistance)
            child.SetActive(false);
        else
            child.SetActive(true);
    }
}

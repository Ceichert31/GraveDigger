using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExperimentRoam : MonoBehaviour
{
    [SerializeField] private Transform[] pointList = new Transform[10];
    private NavMeshAgent agent;

    private int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        index = Random.Range(0, pointList.Length - 1);
        agent.SetDestination(pointList[index].position);
    }
    private void Update()
    {
        if (agent.remainingDistance < 1)
        {
            index = Random.Range(0, pointList.Length - 1);
            agent.SetDestination(pointList[index].position);
        }
    }
}

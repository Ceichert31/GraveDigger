using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum TreeStates
{
    lurking,
    hunting
}
public class TreeMimic : MonoBehaviour
{
    private TreeStates currentState;

    private Transform player;

    private NavMeshAgent agent;

    private Animator anim;

    private float waitTime;
    private void Start()
    {
        player = GameManager.Instance.player;

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TreeBehavior();
    }
    void TreeBehavior()
    {
        switch (currentState)
        {
            case TreeStates.lurking:
                anim.SetBool("IsHunting", false);
                if (Vector3.Distance(transform.position, player.position) < 7)
                    currentState = TreeStates.hunting;
                break;

            case TreeStates.hunting:
                anim.SetBool("IsHunting", true);
                agent.SetDestination(player.position);

                if (Vector3.Distance(transform.position, player.position) > 20)
                {
                    waitTime += Time.deltaTime;
                    if (waitTime >= 10)
                    {
                        currentState = TreeStates.lurking;
                        waitTime = 0;
                    }
                }
                break;
        }
    }
}

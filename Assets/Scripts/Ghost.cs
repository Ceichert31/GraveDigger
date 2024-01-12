using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Ghost : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float
        xPos,
        zPos,
        distance;

    private NavMeshAgent agent;

    public delegate void SpawnGhost(int num);
    public static SpawnGhost spawnGhost;
    private float waitTime = 10;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.Instance.player;

        FindNewRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
    }
    /// <summary>
    /// Find a new random position to move to
    /// </summary>
    void FindNewRandomPos()
    {
        xPos = Random.Range(0, 500);
        zPos = Random.Range(0, 500);

        Vector3 newPos = new(xPos, 0, zPos);

        //Check if Location is unobstructed
        if (Physics.Raycast(newPos, Vector3.down * 1, out RaycastHit hitinfo))
        {
            if (hitinfo.collider.gameObject.transform.position.y > 0)
            {
                FindNewRandomPos();
            }
        }

        transform.position = newPos;
    }
    private void Activate(int num)
    {
        switch (num)
        {
            //Passive
            case 0:
                Debug.Log(distance);
                if (distance < 30)
                    FindNewRandomPos();
                break;

            //Hostile
            case 1:
                agent.SetDestination(player.position);
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    FindNewRandomPos();
                    waitTime = 10;
                }
                break;

            //Dangerous
            case 2:
                agent.speed = 5;
                if (distance < 30)
                    agent.SetDestination(player.position);
                if (distance > 200)
                    FindNewRandomPos();
                break;

            //Death
            case 3:
                agent.SetDestination(player.position);
                agent.speed = 7;
                if (distance > 40)
                {
                    FindNewRandomPos();
                }
                break;
        }


    }
    private void OnEnable()
    {
        spawnGhost += Activate;
    }
    private void OnDisable()
    {
        spawnGhost -= Activate;
    }
}

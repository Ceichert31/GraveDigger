using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GhostState
{
    passive,
    hostile,
    dangerous,
    death,
    end,
}
public class GhostManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GhostState currentState;

    [SerializeField] private GameObject ghost;

    private bool 
        teleported,
        spawned;
    private float 
        timer,
        minutes,
        seconds;

    [SerializeField] private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime();
        switch (currentState)
        {
            case GhostState.passive:
                if (gameManager.points == 25)
                    currentState = GhostState.hostile;
                break;

            case GhostState.hostile:
                Ghost.spawnGhost?.Invoke(1);
                if (gameManager.points == 15)
                    currentState = GhostState.dangerous;
                break;

            case GhostState.dangerous:
                Ghost.spawnGhost?.Invoke(2);
                if (gameManager.points == 3)
                    currentState = GhostState.death;
                break;

            case GhostState.death:
                Ghost.spawnGhost?.Invoke(3);
                if (gameManager.points <= 0)
                    currentState = GhostState.end;
                break;
                
            case GhostState.end:
                if (teleported)
                    break;
                if (gameManager.points <= 0)
                {
                    EndingManager.endGame?.Invoke();
                    teleported = true;
                }
                break;
                }
        }

    void SpawnGhost(int num)
    {
        if (spawned)
            return;
        spawned = true;
        for (int i = 0; i <= num; i++)
        {
            Instantiate(ghost);
        }
        Invoke(nameof(ResetSpawned), 3);
    }
    void ResetSpawned() => spawned = false;

    void DisplayTime()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (seconds > 30 && seconds < 32)
        {
            SpawnGhost(5);
        }

        if (seconds > 120 && seconds < 122)
        {
            SpawnGhost(5);
        }

        if (seconds > 240 && seconds < 242)
        {
            SpawnGhost(5);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public delegate void EndGame();
    public static EndGame endGame;

    [SerializeField] private Transform player;

    void YouWon()
    {
        player.SetPositionAndRotation(transform.position, transform.rotation);
    }
    private void OnEnable()
    {
        endGame += YouWon;
    }
    private void OnDisable()
    {
        endGame -= YouWon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void Collected();
    public static Collected collected;

    public delegate Transform FindPlayer();
    public static FindPlayer findPlayer;

    [SerializeField] private Transform player;

    public int points = 0;

    [SerializeField] private TextMeshProUGUI score;

    private void CollectedCoffin()
    {
        points++;
        score.text = points.ToString();
    }
    private Transform GetPlayerLocation()
    {
        return player;
    }
    private void OnEnable()
    {
        collected += CollectedCoffin;
        findPlayer += GetPlayerLocation;
    }
    private void OnDisable()
    {
        collected -= CollectedCoffin;
        findPlayer -= GetPlayerLocation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void Collected();
    public static Collected collected;

    public Transform player;

    public int points = 30;

    [SerializeField] private TextMeshProUGUI score;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        //Check to see if any other instances exsist with the scene
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    /// <summary>
    /// Add one point to the score
    /// </summary>
    private void CollectedCoffin()
    {
        points--;
        score.text = points.ToString();
    }
    private void OnEnable()
    {
        collected += CollectedCoffin;
    }
    private void OnDisable()
    {
        collected -= CollectedCoffin;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [Header("References")]
    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;
    private PlayerStats playerStats;

    public static PlayerMovement Movement { get { return Instance.playerMovement; } }
    public static PlayerInteraction Interaction { get { return Instance.playerInteraction; } }
    public static PlayerStats Stats { get { return Instance.playerStats; } }
    public static Transform Transform { get { return Instance.transform; } }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        playerMovement = GetComponent<PlayerMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();
        playerStats = GetComponent<PlayerStats>();
    }
}

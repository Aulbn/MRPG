using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float health;

    private void Start()
    {
        health = maxHealth;
    }
}

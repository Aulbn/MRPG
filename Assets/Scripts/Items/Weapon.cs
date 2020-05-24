using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : Item
{
    public enum WeaponType
    {
        OneHanded, TwoHanded, Magic
    }

    [Header("Visual")]
    public WeaponType weaponType;
    public GameObject physicalPrefab;
    [Header("Stats")]
    public float damage;
    public float speed;
}

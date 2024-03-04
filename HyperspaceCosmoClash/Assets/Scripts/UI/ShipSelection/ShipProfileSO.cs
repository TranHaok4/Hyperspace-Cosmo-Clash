using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipProfileSO", menuName = "ScriptableObject/ShipProfileSO")]
public class ShipProfileSO : ScriptableObject
{
    [Header("Ship Stats")]
    [SerializeField] protected string shipName;public string ShipName => shipName;
    [SerializeField] protected Sprite shipSprite;public Sprite ShipSprite => shipSprite;
    [SerializeField] protected int shipHealth;public int ShipHealth => shipHealth;
    [SerializeField] protected int shipSpeed;public int ShipSpeed => shipSpeed;
    [SerializeField] protected float shipShootRate;public float ShipShootRate => shipShootRate;
    [SerializeField] protected int shipDamage;public int ShipDamage => shipDamage;
    

    [Header("Ship Abilities")]
    [SerializeField] protected AbilityStatSO ability1;public AbilityStatSO Ability1 => ability1;
    [SerializeField] protected AbilityStatSO ability2;public AbilityStatSO Ability2 => ability2;
    
    [Header("Ship Shoot Behaviour")]
    [SerializeField] protected ShootingBehaviour shipShootBehaviour;public ShootingBehaviour ShipShootBehaviour => shipShootBehaviour;
    [SerializeField] protected TypeBullet typeBullet;public TypeBullet Typebullet => typeBullet;

}

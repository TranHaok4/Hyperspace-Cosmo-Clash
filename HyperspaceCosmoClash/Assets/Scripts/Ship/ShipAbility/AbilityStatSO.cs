using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityStatSO", menuName = "ScriptableObject/AbilityStatSO")]

public class AbilityStatSO : ScriptableObject
{
    [SerializeField] protected float coolDownTimer;
    public float CoolDownTimer { get => coolDownTimer; }

    [SerializeField] protected string skillName;
}

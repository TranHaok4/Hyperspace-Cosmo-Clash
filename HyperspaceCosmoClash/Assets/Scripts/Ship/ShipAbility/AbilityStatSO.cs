using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a ScriptableObject that holds the statistics for a ship ability.
/// </summary>
[CreateAssetMenu(fileName = "AbilityStatSO", menuName = "ScriptableObject/AbilityStatSO")]
public class AbilityStatSO : ScriptableObject
{
    /// <summary>
    /// The cooldown timer for the ability.
    /// </summary>
    [SerializeField] protected float coolDownTimer;
    public float CoolDownTimer { get => coolDownTimer; }

    /// <summary>
    /// The name of the skill associated with the ability.
    /// </summary>
    [SerializeField] protected string skillName;
}

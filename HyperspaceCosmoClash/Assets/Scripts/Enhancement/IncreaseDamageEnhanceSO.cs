using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ScriptableObject class representing an enhancement that increases damage.
/// </summary>
[CreateAssetMenu(fileName = "IncreaseDamageEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseDamageEnhanceSO")]
public class IncreaseDamageEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected int damageIncreaseValue;
    public UnityAction<int> beApplyEnhance;

    /// <summary>
    /// Applies the enhancement by invoking the beApplyEnhance event with the damage increase value.
    /// </summary>
    public override void ApplyEnhancement()
    {
        OnApplyEnhance();
    }

    protected virtual void OnApplyEnhance()
    {
        if (beApplyEnhance != null)
        {
            beApplyEnhance(damageIncreaseValue);
        }
    }
}

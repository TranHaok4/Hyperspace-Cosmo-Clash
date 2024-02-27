using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ScriptableObject class representing an enhancement that increases the HP (hit points) value.
/// </summary>
[CreateAssetMenu(fileName = "IncreaseHPEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseHPEnhanceSO")]
public class IncreaseHPEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected int hpIncreaseValue;

    public UnityAction<int> beApplyEnhance;

    /// <summary>
    /// Applies the enhancement by invoking the beApplyEnhance event with the hpIncreaseValue.
    /// </summary>
    public override void ApplyEnhancement()
    {
        OnApplyEnhance();
    }

    protected virtual void OnApplyEnhance()
    {
        if (beApplyEnhance != null)
        {
            beApplyEnhance(hpIncreaseValue);
        }
    }
}

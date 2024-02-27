using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ScriptableObject class that represents an enhancement for increasing shoot speed.
/// </summary>
[CreateAssetMenu(fileName = "IncreaseShootSpeedEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseShootSpeedEnhanceSO")]
public class IncreaseShootSpeedEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected float shootspeedValue;

    /// <summary>
    /// Event that is triggered when the enhancement is applied.
    /// </summary>
    public UnityAction<float> beApplyEnhance;

    /// <summary>
    /// Applies the enhancement by invoking the OnApplyEnhance method.
    /// </summary>
    public override void ApplyEnhancement()
    {
        OnApplyEnhance();
    }

    /// <summary>
    /// Invokes the beApplyEnhance event with the shoot speed value.
    /// </summary>
    protected virtual void OnApplyEnhance()
    {
        if (beApplyEnhance != null)
        {
            beApplyEnhance(shootspeedValue);
        }
    }
}

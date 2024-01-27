using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IncreaseDamageEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseDamageEnhanceSO")]
public class IncreaseDamageEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected int damageIncreaseValue;
    public UnityAction<int> beApplyEnhance;
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

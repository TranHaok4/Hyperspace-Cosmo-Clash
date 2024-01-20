using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IncreaseShootSpeedEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseShootSpeedEnhanceSO")]

public class IncreaseShootSpeedEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected float shootspeedValue;


    public UnityAction<float> beApplyEnhance;
    public override void ApplyEnhancement()
    {
        OnApplyEnhance();
    }
    protected virtual void OnApplyEnhance()
    {
        if (beApplyEnhance != null)
        {
            beApplyEnhance(shootspeedValue);
        }
    }
}

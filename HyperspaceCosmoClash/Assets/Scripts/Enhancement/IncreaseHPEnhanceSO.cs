using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IncreaseHPEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseHPEnhanceSO")]
public class IncreaseHPEnhanceSO : EnhancementDataSO
{

    [SerializeField] protected int hpIncreaseValue;

    public UnityAction<int> beApplyEnhance;
    public override void ApplyEnhancement()
    {
        OnApplyEnhance();
    }
    protected virtual void OnApplyEnhance()
    {
        if(beApplyEnhance!=null)
        {
            beApplyEnhance(hpIncreaseValue);
        }
    }
}

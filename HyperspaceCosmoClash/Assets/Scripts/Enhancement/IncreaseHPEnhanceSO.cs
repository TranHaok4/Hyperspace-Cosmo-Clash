using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IncreaseHPEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseHPEnhanceSO")]
public class IncreaseHPEnhanceSO : EnhancementDataSO
{
    [SerializeField] protected int valueHPIncrease;
    protected override void ApplyEnhancement()
    {
        ///todo
    }
}

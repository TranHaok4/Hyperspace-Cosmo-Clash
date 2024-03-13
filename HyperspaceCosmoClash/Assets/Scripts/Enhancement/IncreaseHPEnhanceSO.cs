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

    public override void OnApllyEnhancement(ShipCtrl shipCtrl)
    {
        shipCtrl.ShipDamageReceiver.AddHPmax(hpIncreaseValue);
    }
}

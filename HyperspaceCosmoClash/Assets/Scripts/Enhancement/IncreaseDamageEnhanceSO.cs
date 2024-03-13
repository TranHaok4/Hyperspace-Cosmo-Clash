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

    public override void OnApllyEnhancement(ShipCtrl shipCtrl)
    {
        shipCtrl.ShipShooter.IncreaseShootDamage(damageIncreaseValue);
    }
}

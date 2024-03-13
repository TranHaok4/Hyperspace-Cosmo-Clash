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

    public override void OnApllyEnhancement(ShipCtrl shipCtrl)
    {
        shipCtrl.ShipShooter.IncreaseShootRate(shootspeedValue);
    }
}

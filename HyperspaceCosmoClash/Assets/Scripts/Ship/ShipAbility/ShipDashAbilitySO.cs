using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipDashAbilitySO", menuName = "ScriptableObject/ShipAbilities/ShipDashAbilitySO")]

public class ShipDashAbilitySO : AbilityStatSO
{
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashDuration = 0.3f;   
    [SerializeField] protected float dashTimer = 0f;

    public override void ActiveSkill(ShipCtrl shipCtrl)
    {
        if(abilityState==AbilityState.CoolDown)
        {
            return;
        }
        shipCtrl.StartCoroutine(Dashing(shipCtrl));
        shipCtrl.StartCoroutine(Cooldowning());
    }
    IEnumerator Dashing(ShipCtrl shipCtrl)
    {
        dashTimer = dashDuration;
        float oldShipSpeed = shipCtrl.Shipmovement.Speed;
        while(dashTimer>=0)
        {
            shipCtrl.Shipmovement.SetSpeed(dashSpeed);
            dashTimer -= Time.deltaTime;
            yield return null;
        }
        shipCtrl.Shipmovement.SetSpeed(oldShipSpeed);
    }
}

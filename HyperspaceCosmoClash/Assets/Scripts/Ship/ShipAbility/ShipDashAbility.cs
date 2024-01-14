using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDashAbility : BaseAbility
{
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashDuration = 0.3f;
    [SerializeField] protected float dashTimer = 0f;

    public override void ActiveSkill()
    {
        StartCoroutine(Dashing());
    }
    IEnumerator Dashing()
    {
        //Debug.Log("da vao duoc day");
        dashTimer = dashDuration;
        float oldShipSpeed = this.shipCtrl.Shipmovement.Speed;
        Debug.Log(oldShipSpeed);
        while(dashTimer>=0)
        {
            this.shipCtrl.Shipmovement.SetSpeed(dashSpeed);
            dashTimer -= Time.deltaTime;
            yield return null;
        }
        this.shipCtrl.Shipmovement.SetSpeed(oldShipSpeed);
    }
}

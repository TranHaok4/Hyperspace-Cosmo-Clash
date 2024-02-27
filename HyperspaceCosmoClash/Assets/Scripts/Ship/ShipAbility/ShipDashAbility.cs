using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a ship ability that allows the ship to perform a dash maneuver.
/// </summary>
public class ShipDashAbility : BaseAbility
{
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashDuration = 0.3f;
    [SerializeField] protected float dashTimer = 0f;

    /// <summary>
    /// Activates the dash ability.
    /// </summary>
    public override void ActiveSkill()
    {
        StartCoroutine(Dashing());
    }

    /// <summary>
    /// Coroutine that performs the dash maneuver.
    /// </summary>
    IEnumerator Dashing()
    {
        dashTimer = dashDuration;
        float oldShipSpeed = this.shipCtrl.Shipmovement.Speed;
        while(dashTimer>=0)
        {
            this.shipCtrl.Shipmovement.SetSpeed(dashSpeed);
            dashTimer -= Time.deltaTime;
            yield return null;
        }
        this.shipCtrl.Shipmovement.SetSpeed(oldShipSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }

    public virtual void IncreaseShootRate(float value)
    {
        shootDelay -= value;
    }
}

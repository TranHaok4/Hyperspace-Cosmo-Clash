using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the flying behavior of a meteorite obstacle.
/// </summary>
public class MeteoriteFly : ParentFly
{
    [SerializeField] protected float minCamPos = -10f;
    [SerializeField] protected float maxCamPos = 10f;

    /// <summary>
    /// Resets the value of moveSpeed to 1.
    /// </summary>
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 1f;
    }

    /// <summary>
    /// Called when the object is enabled.
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    /// <summary>
    /// Calculates the fly direction of the meteorite based on the camera position and the parent object's position.
    /// </summary>
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = this.GetCamPos();
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        //Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }

    /// <summary>
    /// Gets the position of the camera in the game world.
    /// </summary>
    /// <returns>The position of the camera.</returns>
    protected virtual Vector3 GetCamPos()
    {
        if (GameCtrl.Instance == null) return Vector3.zero;

        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        return camPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class extends the ObjectLookAtTarget class and allows an object to look at the mouse position in the world.
/// </summary>
public class ObjectLookAtMouse : ObjectLookAtTarget
{
    /// <summary>
    /// Overrides the FixedUpdate method to get the mouse position and update the target position.
    /// </summary>
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

    /// <summary>
    /// Gets the mouse position in the world and sets it as the target position for the object to look at.
    /// </summary>
    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}

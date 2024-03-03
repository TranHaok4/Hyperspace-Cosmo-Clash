using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the movement behavior of an object in the game.
/// </summary>
public class ObjecMovement : HaroMonoBehaviour
{
    [Header("ObjectMovement")]
    [SerializeField] protected float speed = 0.01f;

    /// <summary>
    /// Gets or sets the speed of the object's movement.
    /// </summary>
    public float Speed { get => speed; }

    /// <summary>
    /// Sets the speed of the object's movement.
    /// </summary>
    /// <param name="speed">The new speed value.</param>
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for objects that can shoot bullets.
/// </summary>
public abstract class ObjectShooting : HaroMonoBehaviour
{
    [SerializeField] protected TypeBullet bullet;
    public TypeBullet Bullet { get => bullet; }
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;


    public virtual void SetBulletType(TypeBullet _bullet)
    {
        this.bullet = _bullet;
    }
    protected void Update()
    {
        this.IsShooting();
    }

    protected void FixedUpdate()
    {
        this.Shooting();
    }

    /// <summary>
    /// Performs the shooting logic.
    /// </summary>
    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer <= this.shootDelay) return;
        this.shootTimer = 0;
        this.Shoot(); // Apply the selected shoot type here
    }

    /// <summary>
    /// Abstract method for shooting.
    /// </summary>
    protected abstract void Shoot();

    /// <summary>
    /// Abstract method for checking if the object is shooting.
    /// </summary>
    /// <returns>True if the object is shooting, false otherwise.</returns>
    protected abstract bool IsShooting();
}


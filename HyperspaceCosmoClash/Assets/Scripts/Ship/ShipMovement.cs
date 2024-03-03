using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the ship in the game.
/// </summary>
public class ShipMovement : ObjecMovement
{
    [SerializeField] protected ShipCtrl shipCtrl;

    /// <summary>
    /// Loads the required components for ship movement.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    

    /// <summary>
    /// Loads the ShipCtrl component if it is not already loaded.
    /// </summary>
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    /// <summary>
    /// Initializes the ship's movement speed.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        this.speed = this.shipCtrl.ShipStat.ShipMoveSpeed;
    }

    /// <summary>
    /// Called every fixed frame-rate frame.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    /// <summary>
    /// Moves the ship based on the player's input.
    /// </summary>
    protected virtual void Moving()
    {
        Vector2 movement = new Vector2(InputManager.Instance.HorizontalValue,
        InputManager.Instance.VerticalValue) * speed * Time.fixedDeltaTime;

        Rigidbody2D rb = shipCtrl.RB;
        rb.MovePosition(rb.position + movement);
    }
}

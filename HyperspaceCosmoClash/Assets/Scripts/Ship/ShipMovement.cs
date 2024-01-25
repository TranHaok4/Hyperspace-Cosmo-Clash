using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : ObjecMovement
{
    [SerializeField] protected ShipCtrl shipCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        //Vector3 momevement = new Vector3(InputManager.Instance.HorizontalValue, 
        //InputManager.Instance.VerticalValue,0) * speed * Time.fixedDeltaTime;
        //transform.parent.position += momevement;
        Vector2 movement = new Vector2(InputManager.Instance.HorizontalValue,
        InputManager.Instance.VerticalValue) * speed * Time.fixedDeltaTime;

        Rigidbody2D rb = shipCtrl.RB;
        rb.MovePosition(rb.position + movement);
    }
}

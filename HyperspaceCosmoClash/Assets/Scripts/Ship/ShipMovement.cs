using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : ObjecMovement
{
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        Vector3 momevement = new Vector3(InputManager.Instance.HorizontalValue, 
        InputManager.Instance.VerticalValue,0) * speed * Time.fixedDeltaTime;
        transform.parent.position += momevement;
    }
}

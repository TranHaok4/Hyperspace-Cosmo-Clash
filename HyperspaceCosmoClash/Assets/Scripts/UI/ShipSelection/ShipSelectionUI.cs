using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelectionUI : UIShipSelectionBase
{
    [SerializeField] protected Image shipSprite;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipSprite();
    }
    protected virtual void LoadShipSprite()
    {
        if(shipSprite!=null) return;
        shipSprite = this.GetComponentInChildren<Image>();
        Debug.Log(transform.name + " LoadShipSprite: ",gameObject);
    }
    public override void SetUpUIlogic(ShipProfileSO shipProfile)
    {
        shipSprite.sprite = shipProfile.ShipSprite;
    }

    public override void SetUpUIlogic(){}// no overide needed
}

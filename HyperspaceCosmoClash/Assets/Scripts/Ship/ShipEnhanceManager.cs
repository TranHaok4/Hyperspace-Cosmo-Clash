using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the enhancements for a ship.
/// </summary>
public class ShipEnhanceManager : HaroMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected List<EnhancementDataSO> enhancements;


    protected override void Start()
    {
        base.Start();
        this.InitlizeComponent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    protected virtual void InitlizeComponent()
    {
        foreach (EnhancementDataSO enhance in enhancements)
        {
            //Debug.Log("Enhancement: " + enhance.name);
            enhance.beApplyEnhance += () => enhance.OnApllyEnhancement(shipCtrl);
        }
    }
}

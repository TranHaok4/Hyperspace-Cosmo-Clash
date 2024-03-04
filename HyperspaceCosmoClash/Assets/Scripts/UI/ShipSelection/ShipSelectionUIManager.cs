using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ShipSelectionUIManager : HaroMonoBehaviour
{
    private static ShipSelectionUIManager instance;
    public static ShipSelectionUIManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ShipSelectionUIManager.instance != null) Debug.LogError("Only 1 VFXSpawner allow to exist");
        ShipSelectionUIManager.instance = this;
    }

    [SerializeField] protected List<UIShipSelectionBase> shipSelectionUIs = new List<UIShipSelectionBase>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipSelectionUIs();
    }
    protected virtual void LoadShipSelectionUIs()
    {
        if(shipSelectionUIs.Count>0) return;
        shipSelectionUIs = new List<UIShipSelectionBase>(this.GetComponentsInChildren<UIShipSelectionBase>());
    }

    public virtual void SetInforUIShipSelections(ShipProfileSO shipProfile)
    {
        foreach (var shipSelectionUI in shipSelectionUIs)
        {
            shipSelectionUI.SetUpUIlogic(shipProfile);
        }
    }

}

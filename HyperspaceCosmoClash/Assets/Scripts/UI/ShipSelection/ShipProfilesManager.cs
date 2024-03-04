using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProfilesManager : HaroMonoBehaviour
{

    private static ShipProfilesManager instance;

    public static ShipProfilesManager Instance{get=>instance;}

    protected override void Awake()
    {
        base.Awake();
        if(ShipProfilesManager.instance!=null && ShipProfilesManager.instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            ShipProfilesManager.instance = this;
            DontDestroyOnLoad(this);
        }
    }

    [SerializeField] List<ShipProfileSO> shipProfiles = new List<ShipProfileSO>();
    
    [SerializeField] protected ShipProfileSO currentShipProfile;
    public ShipProfileSO CurrentShipProfile { get => currentShipProfile; }

    protected override void Start()
    {
        base.Start();
        currentShipProfile = shipProfiles?[0];
        ChangeUIs();
    }

    public virtual void NextShipProfile()
    {
        int currentIndex = shipProfiles.IndexOf(currentShipProfile);
        if (currentIndex == shipProfiles.Count - 1)
        {
            currentShipProfile = shipProfiles[0];
        }
        else
        {
            currentShipProfile = shipProfiles[currentIndex + 1];
        }
        ChangeUIs();
    }
    public virtual void BackShipProfile()
    {
        int currentIndex = shipProfiles.IndexOf(currentShipProfile);
        if (currentIndex == 0)
        {
            currentShipProfile = shipProfiles[shipProfiles.Count - 1];
        }
        else
        {
            currentShipProfile = shipProfiles[currentIndex - 1];
        }
        ChangeUIs();
    }

    protected virtual void ChangeUIs()
    {
        ShipSelectionUIManager.Instance.SetInforUIShipSelections(currentShipProfile);
    }
}

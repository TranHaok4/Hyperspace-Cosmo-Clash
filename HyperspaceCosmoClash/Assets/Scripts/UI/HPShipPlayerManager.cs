using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPShipPlayerManager : HaroMonoBehaviour
{
    
    private static HPShipPlayerManager instance;
    public static HPShipPlayerManager Instance { get => instance; }

    public UnityAction<int,int> UpdateHPPlayerShip;

    protected override void Awake()
    {
        base.Awake();
        if (HPShipPlayerManager.instance != null) Debug.LogError("Only 1 HPShipPlayerManager allow to exist");
        HPShipPlayerManager.instance = this;
        Debug.Log("da co HPShipPlayerManager"+Time.deltaTime);
    }

    public void UpdateHPdataShipPlayer(int hp,int maxhp )
    {
        if (UpdateHPPlayerShip != null)
        {
            UpdateHPPlayerShip(hp,maxhp);
        }
    }


}

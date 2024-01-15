using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPShipPlayerNotificater : HaroMonoBehaviour
{
    
    private static HPShipPlayerNotificater instance;
    public static HPShipPlayerNotificater Instance { get => instance; }

    public UnityAction<int,int> UpdateHPPlayerShip;

    protected override void Awake()
    {
        base.Awake();
        if (HPShipPlayerNotificater.instance != null) Debug.LogError("Only 1 HPShipPlayerManager allow to exist");
        HPShipPlayerNotificater.instance = this;
        Debug.Log("da co HPShipPlayerManager");
    }

    public void OnUpdateHPPlayerShipData(int hp,int maxhp )
    {
        if (UpdateHPPlayerShip != null)
        {
            UpdateHPPlayerShip(hp,maxhp);
        }
    }


}

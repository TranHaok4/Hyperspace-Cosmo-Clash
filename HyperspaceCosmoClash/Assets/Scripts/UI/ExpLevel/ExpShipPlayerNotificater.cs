using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpShipPlayerNotificater : HaroMonoBehaviour
{

    private static ExpShipPlayerNotificater instance;
    public static ExpShipPlayerNotificater Instance { get => instance; }

    public UnityAction<int,int> UpdateExpPlayerShip;
    public UnityAction<int> UpdateLevelPlayerShip;


    protected override void Awake()
    {
        base.Awake();
        if (ExpShipPlayerNotificater.instance != null) Debug.LogError("Only 1 ExpShipPlayerManager allow to exist");
        ExpShipPlayerNotificater.instance = this;
        Debug.Log("da co ExpShipPlayerManager" );
    }

    public void OnUpdateExpPlayerShipData(int currentExp,int maxExp)
    {
        if (UpdateExpPlayerShip == null) return;

        UpdateExpPlayerShip(currentExp, maxExp);
    }
    public void OnUpdateLevelPlayerShipData(int currentLevel)
    {
        if (UpdateLevelPlayerShip == null) return;

        UpdateLevelPlayerShip(currentLevel);
    }



}

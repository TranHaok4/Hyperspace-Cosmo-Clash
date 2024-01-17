using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExpShipPlayerNotificater : HaroMonoBehaviour
{

    private static ExpShipPlayerNotificater instance;
    public static ExpShipPlayerNotificater Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (ExpShipPlayerNotificater.instance != null) Debug.LogError("Only 1 ExpShipPlayerManager allow to exist");
        ExpShipPlayerNotificater.instance = this;
        Debug.Log("da co ExpShipPlayerManager" );
    }

    public UnityAction<int, int> updateExpPlayerShip;
    public UnityAction<int> updateLevelPlayerShip;
    public void OnUpdateExpPlayerShipData(int currentExp,int maxExp)
    {
        if (updateExpPlayerShip == null) return;

        updateExpPlayerShip(currentExp, maxExp);
    }
    public void OnUpdateLevelPlayerShipData(int currentLevel)
    {
        if (updateLevelPlayerShip == null) return;

        updateLevelPlayerShip(currentLevel);
    }



}

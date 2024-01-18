using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelExpShipPlayerNotificater : Notificater
{

    private static LevelExpShipPlayerNotificater instance;
    public static LevelExpShipPlayerNotificater Instance { get => instance; }
    protected override void Awake()
    {
        if (LevelExpShipPlayerNotificater.instance != null) Debug.LogError("Only 1 ExpShipPlayerManager allow to exist");
        LevelExpShipPlayerNotificater.instance = this;
        Debug.Log("da co ExpShipPlayerManager");
    }

    public UnityAction<int, int> updateExpPlayerShip;
    public UnityAction<int> updateLevelPlayerShip;

    public void OnUpdateExpPlayerShipData(int currentExp, int maxExp)
    {
        if(updateExpPlayerShip!=null)
        {
            updateExpPlayerShip(currentExp, maxExp);
        }
        else StartCoroutine(WaitforUpdateExpPlayerShip(currentExp,maxExp));
    }
    public void OnUpdateLevelPlayerShipData(int currentLevel)
    {
        if (updateLevelPlayerShip != null)
        {
            updateLevelPlayerShip(currentLevel);
        }
        else StartCoroutine(WaitforUpdateLevelPlayerShip(currentLevel));
    }

    IEnumerator WaitforUpdateExpPlayerShip(int currentExp,int maxExp)
    {
        //Debug.Log("vay la chua co ExpNotificater");
        while (updateExpPlayerShip == null)
        {
            yield return null;
        }
        //Debug.Log("vay la da co ExpNotificater");
        updateExpPlayerShip(currentExp, maxExp);
    }
    IEnumerator WaitforUpdateLevelPlayerShip(int curentLevel)
    {
        //Debug.Log("vay la chua co ExpNotificater");
        while (updateLevelPlayerShip == null)
        {
            yield return null;
        }
        //Debug.Log("vay la da co ExpNotificater");
        updateLevelPlayerShip(curentLevel);
    }

}

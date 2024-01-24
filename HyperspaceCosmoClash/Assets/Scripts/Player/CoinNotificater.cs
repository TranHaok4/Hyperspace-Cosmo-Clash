using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CoinNotificater : Notificater
{
    private static CoinNotificater instance;
    public static CoinNotificater Instance { get => instance; }
    protected override void Awake()
    {
        if (CoinNotificater.instance != null) Debug.LogError("Only 1 CoinNotificater allow to exist");
        CoinNotificater.instance = this;
        Debug.Log("da co HPShipPlayerManager");
    }
    public UnityAction<int> updateCoinValue;

    public void OnUpdateCoinValue(int value)
    {
        if (updateCoinValue != null)
        {
            updateCoinValue(value);
        }
        else
        {
            StartCoroutine(WaitforOnUpdateCoinValue(value));
        }
    }

    IEnumerator WaitforOnUpdateCoinValue(int value)
    {
        while (updateCoinValue == null)
        {
            yield return null;
        }
        updateCoinValue(value);
    }

}

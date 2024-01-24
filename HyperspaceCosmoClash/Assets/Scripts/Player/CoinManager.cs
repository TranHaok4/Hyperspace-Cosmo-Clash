using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : HaroMonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance { get => instance; }

    [SerializeField] protected int coinValue = 0;
    protected override void Awake()
    {
        base.Awake();
        if (CoinManager.instance != null) Debug.LogError("Only 1 CoinManager allow to exist");
        CoinManager.instance = this;
    }
    public virtual void AddCoin(int value)
    {
        coinValue += value;
        NotifyChangeCoinValue();
    }
    protected virtual void NotifyChangeCoinValue()
    {
        CoinNotificater.Instance.OnUpdateCoinValue(coinValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Notifies listeners about changes in the coin value.
/// </summary>
public class CoinNotificater : Notificater
{
    private static CoinNotificater instance;

    /// <summary>
    /// Gets the singleton instance of the CoinNotificater.
    /// </summary>
    public static CoinNotificater Instance { get => instance; }

    protected override void Awake()
    {
        if (CoinNotificater.instance != null) Debug.LogError("Only 1 CoinNotificater allowed to exist");
        CoinNotificater.instance = this;
        //Debug.Log("da co HPShipPlayerManager");
    }

    /// <summary>
    /// Event that is triggered when the coin value is updated.
    /// </summary>
    public UnityAction<int> updateCoinValue;

    /// <summary>
    /// Updates the coin value and notifies listeners.
    /// </summary>
    /// <param name="value">The new coin value.</param>
    public void OnUpdateCoinValue(int value)
    {
        if (updateCoinValue != null)
        {
            updateCoinValue(value);
        }
        else
        {
            StartCoroutine(WaitForOnUpdateCoinValue(value));
        }
    }

    private IEnumerator WaitForOnUpdateCoinValue(int value)
    {
        while (updateCoinValue == null)
        {
            yield return null;
        }
        updateCoinValue(value);
    }
}

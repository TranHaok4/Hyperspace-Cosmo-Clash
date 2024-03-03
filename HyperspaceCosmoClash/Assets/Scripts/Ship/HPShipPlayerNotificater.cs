using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Notificater class for updating the HP (Health Points) of the player's ship.
/// </summary>
public class HPShipPlayerNotificater : Notificater
{
    private static HPShipPlayerNotificater instance;
    public static HPShipPlayerNotificater Instance { get => instance; }

    public UnityAction<int, int> updateHPPlayerShip;

    protected override void Awake()
    {
        if (HPShipPlayerNotificater.instance != null) Debug.LogError("Only 1 HPShipPlayerManager allow to exist");
        HPShipPlayerNotificater.instance = this;
        //Debug.Log("da co HPShipPlayerManager");
    }

    /// <summary>
    /// Updates the HP (Health Points) of the player's ship.
    /// </summary>
    /// <param name="hp">The current HP of the player's ship.</param>
    /// <param name="maxhp">The maximum HP of the player's ship.</param>
    public void OnUpdateHPPlayerShipData(int hp, int maxhp)
    {
        if (updateHPPlayerShip != null)
        {
            updateHPPlayerShip(hp, maxhp);
        }
        else
        {
            StartCoroutine(WaitforOnUpdateHPPlayerShipData(hp, maxhp));
        }
    }

    private IEnumerator WaitforOnUpdateHPPlayerShipData(int hp, int maxhp)
    {
        while (updateHPPlayerShip == null)
        {
            yield return null;
        }
        updateHPPlayerShip(hp, maxhp);
    }
}

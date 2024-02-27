using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Notificater class for notifying level and experience updates of the player's ship.
/// </summary>
public class LevelExpShipPlayerNotificater : Notificater
{

    private static LevelExpShipPlayerNotificater instance;
    public static LevelExpShipPlayerNotificater Instance { get => instance; }
    protected override void Awake()
    {
        if (LevelExpShipPlayerNotificater.instance != null) Debug.LogError("Only 1 ExpShipPlayerManager allow to exist");
        LevelExpShipPlayerNotificater.instance = this;
        //Debug.Log("da co ExpShipPlayerManager");
    }

    public UnityAction<int, int> updateExpPlayerShip;
    public UnityAction<int> updateLevelPlayerShip;

    /// <summary>
    /// Notifies the update of the player's ship experience data.
    /// </summary>
    /// <param name="currentExp">The current experience value.</param>
    /// <param name="maxExp">The maximum experience value.</param>
    public void OnUpdateExpPlayerShipData(int currentExp, int maxExp)
    {
        if(updateExpPlayerShip!=null)
        {
            updateExpPlayerShip(currentExp, maxExp);
        }
        else StartCoroutine(WaitforUpdateExpPlayerShip(currentExp,maxExp));
    }

    /// <summary>
    /// Notifies the update of the player's ship level data.
    /// </summary>
    /// <param name="currentLevel">The current level value.</param>
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

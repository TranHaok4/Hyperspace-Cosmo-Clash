using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossStatsNotificater : Notificater
{
    private static BossStatsNotificater instance;
    public static BossStatsNotificater Instance { get => instance; }

    public UnityAction<bool> updateBossState;
    public UnityAction<int, int> updateBossHP;

    protected override void Awake()
    {
        if (BossStatsNotificater.instance != null) Debug.LogError("Only 1 HPShipPlayerManager allow to exist");
        BossStatsNotificater.instance = this;
        //Debug.Log("da co HPShipPlayerManager");
    }
    public virtual void OnUpdateBossState(bool state)
    {
        if(updateBossState != null)
        {
            updateBossState(state);
        }
        else
        {
            StartCoroutine(WaitforOnUpdateBossState(state));
        }
    }
    IEnumerator WaitforOnUpdateBossState(bool state)
    {
        while (updateBossState == null)
        {
            yield return null;
        }
        updateBossState(state);
    }
    public virtual void OnUpdateBossHP(int hp,int maxhp)
    {
        if (updateBossHP != null)
        {
            updateBossHP(hp,maxhp);
        }
        else
        {
            StartCoroutine(WaitforOnUpdateBossHP(hp,maxhp));
        }
    }
    IEnumerator WaitforOnUpdateBossHP(int hp, int maxhp)
    {
        while (updateBossHP == null)
        {
            yield return null;
        }
        updateBossHP(hp, maxhp);
    }
}


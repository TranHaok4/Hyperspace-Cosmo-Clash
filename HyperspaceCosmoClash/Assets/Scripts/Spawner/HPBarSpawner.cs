using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    private static HPBarSpawner instance;
    public static HPBarSpawner Instance { get => instance; }


    protected override void Awake()
    {
        base.Awake();
        if (HPBarSpawner.instance != null) Debug.LogError("Only 1 VFXSpawner allow to exist");
        HPBarSpawner.instance = this;
    }
}

public enum HPBarType
{
    none=0,
    NormalEnemyHPBar=1,
    BossHPBar=2,
}
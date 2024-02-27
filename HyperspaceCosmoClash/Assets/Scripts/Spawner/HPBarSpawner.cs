using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns HP bars in the game.
/// </summary>
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

/// <summary>
/// Represents the type of HP bar.
/// </summary>
public enum HPBarType
{
    none=0,
    NormalEnemyHPBar=1,
    BossHPBar=2,
}
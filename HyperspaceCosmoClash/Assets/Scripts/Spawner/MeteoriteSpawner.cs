using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns meteorites in the game.
/// </summary>
public class MeteoriteSpawner : Spawner
{
    private static MeteoriteSpawner instance;
    public static MeteoriteSpawner Instance { get => instance; }

    public static string Meteorite1 = "Meteorite1";

    protected override void Awake()
    {
        base.Awake();
        if (MeteoriteSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        MeteoriteSpawner.instance = this;
    }
}

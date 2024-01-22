using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : Spawner
{
    private static VFXSpawner instance;
    public static VFXSpawner Instance { get => instance; }

    public static string vfxone = "VFXBullet1";

    protected override void Awake()
    {
        base.Awake();
        if (VFXSpawner.instance != null) Debug.LogError("Only 1 VFXSpawner allow to exist");
        VFXSpawner.instance = this;
    }
}

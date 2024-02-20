using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSpawner : Spawner
{
    private static VFXSpawner instance;
    public static VFXSpawner Instance { get => instance; }

    public static string vfxone = "BulletImpact1VFX";

    protected override void Awake()
    {
        base.Awake();
        if (VFXSpawner.instance != null) Debug.LogError("Only 1 VFXSpawner allow to exist");
        VFXSpawner.instance = this;
    }
}

[System.Serializable]
public abstract class VFXName
{
    public abstract string GetName();
}

[System.Serializable]
public class ExplosionVFXName:VFXName
{
    [SerializeField] protected ExplosionVFXNameEnum vfxname;
    public override string GetName()
    {
        return vfxname.ToString();
    }
    public enum ExplosionVFXNameEnum
    {
        none = 0,
        ExplosionVFX = 1,
        PlayerExplosionVFX = 2,
        MeteoriteExplosionVFX = 3,
    }
}

[System.Serializable]
public class CommonVFXName : VFXName
{
    [SerializeField] protected CommonVFXNameEnum vfxname;
    public override string GetName()
    {
        return vfxname.ToString();
    }
    public enum CommonVFXNameEnum
    {
        none = 0,
        LevelUPVFX = 1,

    }
}

[System.Serializable]
public class SpawnVFXName : VFXName
{
    [SerializeField] protected SpawnVFXNameEnum vfxname;
    public override string GetName()
    {
        return vfxname.ToString();
    }
    public enum SpawnVFXNameEnum
    {
        none = 0,
        SpawnVFX = 1,
    }
}
[System.Serializable]
public class BulletImpactVFXName : VFXName
{
    [SerializeField] protected BulletImpactVFXNameEnum vfxname;
    public override string GetName()
    {
        return vfxname.ToString();
    }
    public enum BulletImpactVFXNameEnum
    {
        none = 0,
        RedBulletImpact1VFX = 1,
        GreenBulletImpact1VFX=2,w
    }
}
[System.Serializable]
public class ShieldImpactVFXName : VFXName
{
    [SerializeField] protected ShieldImpactVFXNameEnum vfxname;
    public override string GetName()
    {
        return vfxname.ToString();
    }
    public enum ShieldImpactVFXNameEnum
    {
        none = 0,
        BossShieldImpactVFX = 1,
    }
}


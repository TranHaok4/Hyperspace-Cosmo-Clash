using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }


    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBartoOBJ(newPrefab);
        return newPrefab;
    }
    protected virtual void AddHPBartoOBJ(Transform newprefab)
    {
        EnemyCtrl newEnemyCtrl = newprefab.GetComponent<EnemyCtrl>();
        string nameHPbar = newEnemyCtrl.HPBartype.ToString();
        Transform newHPbar = HPBarSpawner.Instance.Spawn(nameHPbar, newprefab.position, Quaternion.identity);
        newHPbar.GetComponent<EnemyHPBarCtrl>().SetEnemyCtrl(newEnemyCtrl);
        newHPbar.gameObject.SetActive(true);
    }
}
public enum EnemyName
{
    none=0,
    SpiKami=1,
    RdFighter=2,
    RdHoperTurret=3,
    SuperTurtle=4,
}

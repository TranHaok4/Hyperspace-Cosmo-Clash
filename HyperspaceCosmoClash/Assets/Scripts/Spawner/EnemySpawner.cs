using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns enemy objects in the game.
/// </summary>
public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;

    /// <summary>
    /// Gets the instance of the EnemySpawner.
    /// </summary>
    public static EnemySpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }

    /// <summary>
    /// Spawns an enemy object at the specified position and rotation.
    /// </summary>
    /// <param name="prefab">The enemy prefab to spawn.</param>
    /// <param name="spawnPos">The position to spawn the enemy.</param>
    /// <param name="rotation">The rotation of the spawned enemy.</param>
    /// <returns>The spawned enemy object.</returns>
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
        Transform newHPbar = HPBarSpawner.Instance?.Spawn(nameHPbar, newprefab.position, Quaternion.identity);
        newHPbar?.GetComponent<EnemyHPBarCtrl>().SetEnemyCtrl(newEnemyCtrl);
        newHPbar?.gameObject.SetActive(true);
    }
}
/// <summary>
/// Represents the names of different enemy types.
/// </summary>
public enum EnemyName
{
    none=0,
    SpiKami=1,
    RdFighter=2,
    RdHoperTurret=3,
    SuperTurtle=4,
    RedSmg,
    RedSniper,
    
}

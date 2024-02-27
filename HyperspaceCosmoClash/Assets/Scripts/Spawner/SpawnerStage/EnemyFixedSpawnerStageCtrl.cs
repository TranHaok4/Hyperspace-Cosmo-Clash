using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the fixed enemy spawner stage.
/// </summary>
public class EnemyFixedSpawnerStageCtrl : EnemySpawnerStageCtrl
{
    /// <summary>
    /// Called when the object becomes enabled and active.
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        this.SpawnFixedEnemy();
    }

    /// <summary>
    /// Spawns fixed enemies at predefined positions.
    /// </summary>
    protected virtual void SpawnFixedEnemy()
    {
        Debug.Log("spawn ne");
        foreach(Transform pos in Spawnpoints.Points)
        {
            this.Spawn(enemyNames[0], pos.position, pos.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class that spawns enemies randomly.
/// </summary>
public class EnemySpawnRandom : SpawnRandom
{
    /// <summary>
    /// Loads the spawner controller.
    /// </summary>
    protected override void LoadSpawnerCtrl()
    {
        base.LoadSpawnerCtrl();
    }

    /// <summary>
    /// Spawns enemies randomly.
    /// </summary>
    
    
    protected override void Spawning()
    {
        if (!isSpawning) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer <= randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.spawnerStageCtrl.Spawnpoints.GetRandomPoint();
        Vector3 pos = randPoint.position;
        Quaternion rot = randPoint.rotation;

        EnemyName enemy_name = this.spawnerStageCtrl.GetComponent<EnemySpawnerStageCtrl>().GetRandomEnemy();
        this.spawnerStageCtrl.GetComponent<EnemySpawnerStageCtrl>().Spawn(enemy_name, pos, rot);
    }
    
}
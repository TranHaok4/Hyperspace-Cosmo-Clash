using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedSpawnerStageCtrl : EnemySpawnerStageCtrl
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.SpawnFixedEnemy();
    }
    protected virtual void SpawnFixedEnemy()
    {
        Debug.Log("spawn ne");
        foreach(Transform pos in Spawnpoints.Points)
        {
            this.Spawn(enemyNames[0], pos.position, pos.rotation);
        }
    }
}

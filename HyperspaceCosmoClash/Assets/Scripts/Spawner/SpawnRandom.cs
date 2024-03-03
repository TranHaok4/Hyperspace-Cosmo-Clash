using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the random spawning of objects in the game.
/// </summary>
public class SpawnRandom : HaroMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerStageCtrl spawnerStageCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected bool isSpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerStageCtrl != null) return;
        this.spawnerStageCtrl = GetComponent<SpawnerStageCtrl>();
        Debug.LogWarning(transform.name + ":SpawnerCtrl", gameObject);
    }
    protected void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (!isSpawning) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer <= randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.spawnerStageCtrl.Spawnpoints.GetRandomPoint();
        Vector3 pos = randPoint.position;
        Quaternion rot = randPoint.rotation;

        Transform prefab = this.spawnerStageCtrl.SPawner.RandomPrefab();
        Transform obj = this.spawnerStageCtrl.SPawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : HaroMonoBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 4f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
        
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.LogWarning(transform.name + ":SpawnerCtrl", gameObject);
    }
    protected void FixedUpdate()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        if (this.ReachRandomLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer <= randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.spawnerCtrl.Spawnpoints.GetRandomPoint();
        Vector3 pos = randPoint.position;
        Quaternion rot = randPoint.rotation;

        Transform prefab = this.spawnerCtrl.SPawner.RandomPrefab();
        Transform obj = this.spawnerCtrl.SPawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool ReachRandomLimit()
    {
        int currentObject = this.spawnerCtrl.SPawner.SpawnedCount;
        return currentObject >= this.randomLimit;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : HaroMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner SPawner { get => spawner; }

    [SerializeField] protected SpawnPoints spawnpoints;
    public SpawnPoints Spawnpoints { get => spawnpoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnpoints != null) return;
        this.spawnpoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}

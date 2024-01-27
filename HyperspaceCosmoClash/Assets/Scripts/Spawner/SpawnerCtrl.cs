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
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnpoints != null) return;
        this.spawnpoints = GetComponent<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}

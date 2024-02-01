using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStageCtrl : HaroMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner SPawner { get => spawner; }

    [SerializeField] protected SpawnPoints spawnpoints;
    public SpawnPoints Spawnpoints { get => spawnpoints; }

    [SerializeField] protected int maxNumberSpawner = 0;
    [SerializeField] protected int currentNumberSpawner = 0;
    [SerializeField] protected int numberLimitAtOnceTime = 4;
    [SerializeField] protected int numberCurrentOnceTime = 0;
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

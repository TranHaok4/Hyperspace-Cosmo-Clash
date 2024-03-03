using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns special effects (SFX) objects in the game.
/// </summary>
public class SFXSpawner : Spawner
{
    private static SFXSpawner instance;
    public static SFXSpawner Instance { get => instance; }


    protected override void Awake()
    {
        base.Awake();
        if (SFXSpawner.instance != null) Debug.LogError("Only 1 SFXSpawner allow to exist");
        SFXSpawner.instance = this;
    }
    public virtual Transform Spawn(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool();
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool()
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            this.poolObjs.Remove(poolObj);
            return poolObj;
        }
        Transform newPrefab = new GameObject().transform;
        newPrefab.gameObject.AddComponent<AudioSource>();
        newPrefab.gameObject.AddComponent<SFXDespawning>();
        return newPrefab;
    }
}

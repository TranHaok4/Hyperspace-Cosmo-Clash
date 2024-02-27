using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for spawning game objects.
/// </summary>
public abstract class Spawner : HaroMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHodler", gameObject);
    }
    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();

    }
    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Spawns a game object based on the provided prefab name, position, and rotation.
    /// </summary>
    /// <param name="prefabName">The name of the prefab to spawn.</param>
    /// <param name="spawnPos">The position to spawn the prefab at.</param>
    /// <param name="rotation">The rotation of the spawned prefab.</param>
    /// <returns>The spawned game object's Transform component.</returns>
    public virtual Transform Spawn(string prefabName,Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab==null)
        {
            Debug.LogWarning("Prefab not found:" + prefabName);
            return null ;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }
    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            //Debug.Log(prefab.name + "===" + prefabName);
            if (prefab.name == prefabName) return prefab;
        }
        return null;//TO-DO
    }
    /// <summary>
    /// Spawns a new instance of the specified prefab at the given position and rotation.
    /// </summary>
    /// <param name="prefab">The prefab to spawn.</param>
    /// <param name="spawnPos">The position to spawn the prefab at.</param>
    /// <param name="rotation">The rotation to apply to the spawned prefab.</param>
    /// <returns>The spawned prefab as a Transform.</returns>
    public virtual Transform Spawn(Transform prefab,Vector3 spawnPos,Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }


    /// <summary>
    /// Despawns the specified object by adding it back to the object pool and deactivating it.
    /// </summary>
    /// <param name="obj">The object to despawn.</param>
    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    /// <summary>
    /// Returns a random prefab from the list of prefabs.
    /// </summary>
    /// <returns>The randomly selected prefab.</returns>
    public virtual Transform RandomPrefab()
    {
        int rand = UnityEngine.Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}

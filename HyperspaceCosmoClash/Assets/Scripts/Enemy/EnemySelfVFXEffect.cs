using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a visual effects effect for an enemy object.
/// </summary>
public class EnemySelfVFXEffect : ObjectSelfVFXEffect
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Material originalMaterial;
    [SerializeField] protected SpawnVFXName spawnVFXName;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadOrigninalMaterial();
    }
    protected virtual void LoadOrigninalMaterial()
    {
        this.originalMaterial = this.enemyCtrl.Model.material;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.enemyCtrl.Model.material = originalMaterial;
        this.StartCoroutine(BeSpawnCoroutine());
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
    }

    protected override IEnumerator VFXCoroutine()
    {
        this.enemyCtrl.Model.material = vfxMaterial;
        yield return new WaitForSeconds(duration);
        this.enemyCtrl.Model.material = originalMaterial;
    }
    protected virtual IEnumerator BeSpawnCoroutine()
    {
        StartSpawned();
        yield return new WaitForSeconds(0.7f);
        EndSpawned();
    }
    protected virtual void StartSpawned()
    {
        enemyCtrl.Model?.gameObject.SetActive(false);
        enemyCtrl.EnemyDamagereceiver?.gameObject.SetActive(false);
        enemyCtrl.Enemymovement?.gameObject.SetActive(false);
        if(VFXSpawner.Instance!=null)
        {
            Transform newprefab = VFXSpawner.Instance.Spawn(spawnVFXName.GetName(), transform.position, transform.rotation);
            newprefab.gameObject.SetActive(true);
        }
        //Transform newprefab =VFXSpawner.Instance.Spawn(spawnVFXName.GetName(), transform.position, transform.rotation);
        //if(newprefab!=null)
        //{
        //    Debug.Log("HAHA SPAWN");

        //    newprefab.gameObject.SetActive(true);
        //}
        //else
        //{
        //    Debug.Log("HAHA");
        //}
    }
    protected virtual void EndSpawned()
    {
        enemyCtrl.Model?.gameObject.SetActive(true);
        enemyCtrl.EnemyDamagereceiver?.gameObject.SetActive(true);
        enemyCtrl.Enemymovement?.gameObject.SetActive(true);
    }
}

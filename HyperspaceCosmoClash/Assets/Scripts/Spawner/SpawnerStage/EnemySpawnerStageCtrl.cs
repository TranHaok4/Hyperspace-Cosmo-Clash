using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the spawning of enemies in a stage.
/// </summary>
public class EnemySpawnerStageCtrl : SpawnerStageCtrl
{
    [SerializeField] protected List<EnemyName> enemyNames;
    [SerializeField] protected int stageId;

    /// <summary>
    /// Gets the ID of the stage.
    /// </summary>
    public int StageID { get => stageId; }

    /// <summary>
    /// Gets a random enemy from the list of enemy names.
    /// </summary>
    /// <returns>A random enemy name.</returns>
    public virtual EnemyName GetRandomEnemy()
    {
        int rand = UnityEngine.Random.Range(0, this.enemyNames.Count);
        return enemyNames[rand];
    }

    /// <summary>
    /// Spawns an enemy at the specified position and rotation.
    /// </summary>
    /// <param name="name">The name of the enemy to spawn.</param>
    /// <param name="pos">The position to spawn the enemy.</param>
    /// <param name="rot">The rotation of the spawned enemy.</param>
    public virtual void Spawn(EnemyName name, Vector3 pos, Quaternion rot)
    {
        if (currentNumberSpawner >= maxNumberSpawner || numberCurrentOnceTime >= numberLimitAtOnceTime) return;

        currentNumberSpawner++;
        numberCurrentOnceTime++;

        Transform obj = spawner.Spawn(name.ToString(), pos, rot);
        obj.gameObject.SetActive(true);
        EnemyDespawn enemyDespawn = obj.gameObject.GetComponent<EnemyCtrl>().Enemydespawn;
        if (enemyDespawn != null)
        {
            enemyDespawn.OnDespawmObjectCallBack += ChangeEnemyNumber;
        }
        else
        {
            Debug.LogWarning("Not found EnemyDespawn");
        }

        void ChangeEnemyNumber()
        {
            numberCurrentOnceTime--;
            //Debug.Log("Change despawn:" + currentNumberSpawner + " " + numberCurrentOnceTime);
            StageSpawnerManager.Instance.CheckCondition(name);
            enemyDespawn.OnDespawmObjectCallBack -= ChangeEnemyNumber;
        }
    }
}

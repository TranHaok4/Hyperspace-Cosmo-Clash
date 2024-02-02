using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerStageCtrl : SpawnerStageCtrl
{
    [SerializeField] protected List<EnemyName> enemyNames;
    [SerializeField] protected int stageId;
    public int StageID { get => stageId; }

    public virtual EnemyName GetRandomEnemy()
    {
        int rand = UnityEngine.Random.Range(0, this.enemyNames.Count);
        return enemyNames[rand];
    }
    public virtual void Spawn(EnemyName name,Vector3 pos,Quaternion rot)
    {
        if (currentNumberSpawner >= maxNumberSpawner || numberCurrentOnceTime>=numberLimitAtOnceTime) return;
        currentNumberSpawner++;
        numberCurrentOnceTime++;

        Transform obj =spawner.Spawn(name.ToString(), pos, rot);
        obj.gameObject.SetActive(true);
        EnemyDespawn enemyDespawn = obj.gameObject.GetComponent<EnemyCtrl>().Enemydespawn;
        if (enemyDespawn != null)
        {
            enemyDespawn.OnDespawmObjectCallBack = () =>
              {
                  ChangeEnemyNumber(name);
              };
        }
        else Debug.LogWarning("Not found EnemyDespawn");
    }

    protected virtual void ChangeEnemyNumber(EnemyName name)
    {
        numberCurrentOnceTime--;
        StageSpawnerManager.Instance.CheckCondition(name);
    }
}

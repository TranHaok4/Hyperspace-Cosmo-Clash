using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerStageCtrl : SpawnerStageCtrl
{
    [SerializeField] protected List<EnemyName> enemyNames;


    public virtual string GetRandomEnemy()
    {
        int rand = UnityEngine.Random.Range(0, this.enemyNames.Count);
        return enemyNames[rand].ToString();
    }
    public virtual void Spawn(string name,Vector3 pos,Quaternion rot)
    {
        if (currentNumberSpawner >= maxNumberSpawner || numberCurrentOnceTime>=numberLimitAtOnceTime) return;
        currentNumberSpawner++;
        numberCurrentOnceTime++;

        Transform obj =spawner.Spawn(name, pos, rot);
        obj.gameObject.SetActive(true);
        EnemyDespawn enemyDespawn = obj.gameObject.GetComponent<EnemyCtrl>().Enemydespawn;
        if (enemyDespawn != null)
        {
            enemyDespawn.OnDespawmObjectCallBack = () =>
              {
                  DecreaseNumber();
              };
        }
        else Debug.LogWarning("Not found EnemyDespawn");
    }

    protected virtual void DecreaseNumber()
    {
        numberCurrentOnceTime--;
    }
}

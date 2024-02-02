using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawnerManager : HaroMonoBehaviour
{
    private static StageSpawnerManager instance;
    public static StageSpawnerManager Instance { get => instance; }
    protected override void Awake()
    {
        if (StageSpawnerManager.instance != null) Debug.LogError("only 1 StageSpawnManager");
        StageSpawnerManager.instance = this;
    }
    [System.Serializable]
    protected class EnemyDespawnCondition
    {
        [SerializeField] public EnemyName name;
        [SerializeField] public int number;
    }
    [SerializeField] protected List<EnemyDespawnCondition> enemyDespawnConditions;
    [SerializeField] protected StageDataSO currentStageData;
    [SerializeField] protected EnemySpawnerStageCtrl currentSpawnerStageCtrl;
    [SerializeField] List<EnemySpawnerStageCtrl> spawnerStageCtrls;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerStageCtrls();
    }
    protected virtual void LoadSpawnerStageCtrls()
    {
        if (spawnerStageCtrls.Count > 0) return;
        foreach(Transform obj in transform)
        {
            if(obj.GetComponent<EnemySpawnerStageCtrl>()!=null)
            {
                spawnerStageCtrls.Add(obj.GetComponent<EnemySpawnerStageCtrl>());
            }
        }
        foreach(EnemySpawnerStageCtrl obj in spawnerStageCtrls)
        {
            obj.gameObject.SetActive(false);
        }
        Debug.Log(transform.name + "LoadSpawnerStageCtrls", gameObject);

    }
    protected virtual void ResetData()
    {
        for(int i=0;i<enemyDespawnConditions.Count;i++)
        {
            enemyDespawnConditions[i].number = 0;
        }
    }
    public virtual void SetCurrentStageData(StageDataSO data,int stageid)
    {
        currentStageData = data;
        foreach(EnemySpawnerStageCtrl enemySpawnerStage in spawnerStageCtrls)
        {
            
            if(enemySpawnerStage.StageID==stageid)
            {
                currentSpawnerStageCtrl = enemySpawnerStage;
                break;
            }
        }
        currentSpawnerStageCtrl.gameObject.SetActive(true);
        this.ResetData();
    }
    public virtual void CheckCondition(EnemyName enemyname)
    {
        bool flag = true;
        for(int i=0;i<enemyDespawnConditions.Count;i++)
        {
            EnemyName _name = enemyDespawnConditions[i].name;
            if (enemyname == _name)
            {
                enemyDespawnConditions[i].number++;
            }
            int _number = enemyDespawnConditions[i].number;
            for(int j=0;j<currentStageData.Conditions.Count;j++)
            {
                if(currentStageData.Conditions[i].name==_name)
                {
                    Debug.Log(currentStageData.Conditions[i].numberEnemy);
                    Debug.Log(_number);
                    if(currentStageData.Conditions[i].numberEnemy!=_number)
                    {
                        flag = false;
                    }
                }
            }
        }
        if(flag==true)  
        {
            Debug.Log("ok I'm fine");
            currentSpawnerStageCtrl.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("no it don't reach ");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the spawning and despawning of enemy stages in the game.
/// </summary>
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
        public EnemyDespawnCondition(EnemyName name, int number)
        {
            this.name = name;
            this.number = number;
        }
    }
    [SerializeField] protected List<EnemyDespawnCondition> enemyDespawnConditions;
    [SerializeField] protected StageDataSO currentStageData;
    [SerializeField] protected EnemySpawnerStageCtrl currentSpawnerStageCtrl;
    private bool isCurrentStageUnlock=false;
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
        enemyDespawnConditions.Clear();
        for(int i=0;i<currentStageData.Conditions.Count;i++)
        {
            enemyDespawnConditions.Add(new EnemyDespawnCondition(currentStageData.Conditions[i].name, 0));
        }
    }
    /// <summary>
    /// Sets the current stage data and activates the corresponding enemy spawner stage control.
    /// </summary>
    /// <param name="data">The stage data to set.</param>
    /// <param name="stageid">The ID of the stage.</param>
    public virtual void SetCurrentStageData(StageDataSO data,int stageid)
    {
        currentStageData = data;
        isCurrentStageUnlock = false;
        foreach(EnemySpawnerStageCtrl enemySpawnerStage in spawnerStageCtrls)
        {
            
            if(enemySpawnerStage.StageID==stageid)
            {
                currentSpawnerStageCtrl = enemySpawnerStage;
                break;
            }
        }
        currentSpawnerStageCtrl?.gameObject.SetActive(true);
        this.ResetData();
    }
    /// <summary>
    /// Checks the condition for despawning an enemy based on its name.
    /// </summary>
    /// <param name="enemyname">The name of the enemy.</param>
    
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
            //Debug.Log(_name.ToString()+" "+ enemyname.ToString());
            int _number = enemyDespawnConditions[i].number;
            for(int j=0;j<currentStageData.Conditions.Count;j++)
            {
                if(currentStageData.Conditions[j].name==_name)
                {
                    //Debug.Log(currentStageData.Conditions[j].numberEnemy+" "+_number);

                    if(currentStageData.Conditions[j].numberEnemy >_number)
                    {
                        flag = false;
                    }
                }
            }
        }
        if(flag==true && isCurrentStageUnlock==false)  
        {
            //Debug.Log("ok I'm fine");
            currentSpawnerStageCtrl.gameObject.SetActive(false);    
            ObstacleStageManager.Instance.TurnOffObstacleStage(currentSpawnerStageCtrl.StageID);
            isCurrentStageUnlock = true;
        }
        else
        {
            //Debug.Log("no it don't reach ");
        }
    }

}

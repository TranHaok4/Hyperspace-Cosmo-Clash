using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStageManager : HaroMonoBehaviour
{
    private static ObstacleStageManager instance;
    public static ObstacleStageManager Instance { get => instance; }
    protected override void Awake()
    {
        if (ObstacleStageManager.instance != null) Debug.LogError("only 1 ObstacleStageManager");
        ObstacleStageManager.instance = this;
    }
    [SerializeField] protected List<ObstacleLazerStageActiver> obstacleLazerS;
    protected override void LoadComponents()
    {
        Debug.Log("haha");
        base.LoadComponents();
        this.LoadObstacleLazerStageActiver();
    }

    protected virtual void LoadObstacleLazerStageActiver()
    {
        if (this.obstacleLazerS.Count > 0) return;
        foreach(Transform obj in transform)
        {
            ObstacleLazerStageActiver _obstacleLazerStageActiver = obj.gameObject.GetComponentInChildren<ObstacleLazerStageActiver>();
            if (_obstacleLazerStageActiver != null)
            {
                obstacleLazerS.Add(_obstacleLazerStageActiver);
            }
        }
        foreach(ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            Debug.Log(obj.transform.parent.name);
            obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOffLazer();
        }
        Debug.Log(transform.name + "LoadObstacleLazerStageActiver", gameObject);
    }
    public virtual void TurnOnObstacleStage(int stageid)
    {
        foreach (ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            if(obj.StageID==stageid)
            {
                obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOnLazer();
            }
        }
    }
    public virtual void TurnOffObstacleStage(int stageid)
    {
        foreach (ObstacleLazerStageActiver obj in obstacleLazerS)
        {
            if (obj.StageID == stageid)
            {
                obj.Obstaclesctrl.ObstaclesLazercontrol.TurnOffLazer();
            }
        }
    }
}

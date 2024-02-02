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
        base.LoadComponents();
        this.LoadObstacleLazers();
    }

    protected virtual void LoadObstacleLazers()
    {
        if (this.obstacleLazerS.Count > 0) return;
        foreach(Transform obj in transform)
        {
        }
    }
}

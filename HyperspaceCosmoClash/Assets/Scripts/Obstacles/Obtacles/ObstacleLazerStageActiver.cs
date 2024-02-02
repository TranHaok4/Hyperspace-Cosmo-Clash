using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLazerStageActiver : HaroMonoBehaviour
{
    [SerializeField] protected ObstaclesCtrl obstaclesCtrl;
    [SerializeField] protected int gatenumber;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstaclesCtrl != null) return;
        this.obstaclesCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }




}

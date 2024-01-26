using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ObstaclesLazerPoints obstaclePoint;
    public ObstaclesLazerPoints ObstaclePoint { get => obstaclePoint; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstaclePoint();
    }
    protected virtual void LoadObstaclePoint()
    {
        if (this.obstaclePoint != null) return;
        this.obstaclePoint = GetComponentInChildren<ObstaclesLazerPoints>();
        Debug.Log(transform.name + "LoadObstaclePoint", gameObject);
    }
}

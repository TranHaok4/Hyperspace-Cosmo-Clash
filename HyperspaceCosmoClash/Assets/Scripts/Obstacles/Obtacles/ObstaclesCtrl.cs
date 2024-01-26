using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ObstaclesLazerPoints obstaclePoint;
    public ObstaclesLazerPoints ObstaclePoint { get => obstaclePoint; }

    [SerializeField] protected ObstaclesDamageSender obstacleDamageSender;
    public ObstaclesDamageSender ObstaclesDamagesender { get => obstacleDamageSender; }

    [SerializeField] protected ObstaclesVisual obstacleVisual;
    public ObstaclesVisual Obstaclevisual { get => obstacleVisual; }

    [SerializeField] protected ObstaclesImpart obstacleImpart;
    public ObstaclesImpart ObstacleImpart { get => obstacleImpart; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstaclePoint();
        this.LoadObstaclesDamageSender();
        this.LoadObstacleVisual();
        this.LoadObstaclesImpart();
    }
    protected virtual void LoadObstaclePoint()
    {
        if (this.obstaclePoint != null) return;
        this.obstaclePoint = GetComponentInChildren<ObstaclesLazerPoints>();
        Debug.Log(transform.name + "LoadObstaclePoint", gameObject);
    }
    protected virtual void LoadObstaclesDamageSender()
    {
        if (this.obstacleDamageSender != null) return;
        this.obstacleDamageSender = GetComponentInChildren<ObstaclesDamageSender>();
        Debug.Log(transform.name + "LoadObstaclesDamageSender", gameObject);
    }
    protected virtual void LoadObstacleVisual()
    {
        if (this.obstacleVisual != null) return;
        this.obstacleVisual = GetComponentInChildren<ObstaclesVisual>();
        Debug.Log(transform.name + "LoadObstacleVisual", gameObject);
    }
    protected virtual void LoadObstaclesImpart()
    {
        if (this.obstacleImpart != null) return;
        this.obstacleImpart = GetComponentInChildren<ObstaclesImpart>();
        Debug.Log(transform.name + "LoadObstaclesImpart", gameObject);
    }
}

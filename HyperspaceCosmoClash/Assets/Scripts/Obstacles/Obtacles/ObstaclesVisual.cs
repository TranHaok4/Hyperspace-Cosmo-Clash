using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ObstaclesVisual : HaroMonoBehaviour
{
    [SerializeField] protected LineRenderer lineRenderer;
    public LineRenderer Linerenderer { get => lineRenderer; }

    [SerializeField] protected ObstaclesCtrl obstacleCtrl;
    protected Vector2 startPoint, endPoint;


    protected override void Reset()
    {
        base.Reset();
        this.ResizeLaser();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResizeLaser();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
        this.LoadLineRenderer();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstacleCtrl != null) return;
        this.obstacleCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }
    protected virtual void LoadLineRenderer()
    {
        if (this.lineRenderer != null) return;
        this.lineRenderer = GetComponent<LineRenderer>();
        Debug.Log(transform.name + "LoadLineRenderer", gameObject);
    }
    protected virtual void ResizeLaser()
    {
        startPoint = obstacleCtrl.ObstaclePoint.Position1.position;
        endPoint = obstacleCtrl.ObstaclePoint.Position2.position;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }


}

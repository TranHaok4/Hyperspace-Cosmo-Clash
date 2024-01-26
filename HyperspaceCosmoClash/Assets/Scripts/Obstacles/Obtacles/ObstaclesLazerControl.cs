using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObstaclesLazerControl : HaroMonoBehaviour
{
    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected BoxCollider2D boxCollider2D;

    [SerializeField] protected ObstaclesCtrl obstacleCtrl;
    protected Vector2 startPoint, endPoint;


    protected override void Reset()
    {
        base.Reset();
        this.ResizeLaser();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
        this.LoadLineRenderer();
        this.LoadBoxCollider2D();
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
    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        Debug.Log(transform.name + "LoadBoxCollider2D", gameObject);
    }
    protected virtual void ResizeLaser()
    {
        startPoint = obstacleCtrl.ObstaclePoint.Position1.position;
        endPoint = obstacleCtrl.ObstaclePoint.Position2.position;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
        this.ResizeCollider();

    }
    protected virtual void ResizeCollider()
    {
        Vector3 startPoint = lineRenderer.GetPosition(0);
        Vector3 endPoint = lineRenderer.GetPosition(1);

        Vector3 midPoint = (startPoint + endPoint) / 2;
        boxCollider2D.transform.position = midPoint;
        float laserLength = Vector3.Distance(startPoint, endPoint);

        boxCollider2D.size = new Vector2(laserLength, 0.5f);
        boxCollider2D.transform.right = (endPoint - startPoint).normalized;
    }


}

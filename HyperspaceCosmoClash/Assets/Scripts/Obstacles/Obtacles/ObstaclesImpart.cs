using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObstaclesImpart : HaroMonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;

    [SerializeField] protected ObstaclesCtrl obstacleCtrl;
    protected Vector2 startPoint, endPoint;


    protected override void Reset()
    {
        base.Reset();
        this.ResizeCollider();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
        this.LoadBoxCollider2D();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstacleCtrl != null) return;
        this.obstacleCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
        Debug.Log(transform.name + "LoadBoxCollider2D", gameObject);
    }

    protected virtual void ResizeCollider()
    {
        LineRenderer lineRenderer = this.obstacleCtrl.Obstaclevisual.Linerenderer;

        Vector3 startPoint = lineRenderer.GetPosition(0);
        Vector3 endPoint = lineRenderer.GetPosition(1);

        Vector3 midPoint = (startPoint + endPoint) / 2;
        boxCollider2D.transform.position = midPoint;
        float laserLength = Vector3.Distance(startPoint, endPoint);

        boxCollider2D.size = new Vector2(laserLength, 0.3f);
        boxCollider2D.transform.right = (endPoint - startPoint).normalized;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.obstacleCtrl.ObstaclesDamagesender.SendDamage(other.transform);
    }
}

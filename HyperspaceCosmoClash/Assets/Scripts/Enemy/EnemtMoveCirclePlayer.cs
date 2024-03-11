using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtMoveCirclePlayer : EnemyMoveForward
{
    [SerializeField] protected float distancetoMoveCircle=10f;

    private float angle = 0f; 

    protected override void Moving()
    {
        if(Vector3.Distance(transform.parent.position, targetPosition) < distancetoMoveCircle)
        {
            float radius=Vector3.Distance(transform.parent.position, targetPosition);
            angle += this.speed * Time.deltaTime;
            float x = transform.parent.position.x + radius * Mathf.Cos(angle);
            float y = transform.parent.position.y + radius * Mathf.Sin(angle);
            transform.position = new Vector3(x, y, transform.position.z);
        }
        else base.Moving();
    }
}

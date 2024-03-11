using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCirclePlayer : EnemyMoveForward
{
    [SerializeField] protected float distanceToMoveCircle = 10f;
    [SerializeField] private float angle = 0f; 
    private float radius = 0f; 
    private bool enteredCircle = false; 

    protected override void Moving()
    {
        if (Vector3.Distance(transform.parent.position, enemyCtrl.EnemyLookatplayer.TargetPosition) < distanceToMoveCircle)
        {

            if (!enteredCircle) 
            {
                radius = Vector3.Distance(transform.parent.position, enemyCtrl.EnemyLookatplayer.TargetPosition);
                enteredCircle = true;
                float initialAngle = Mathf.Atan2(transform.parent.position.y - enemyCtrl.EnemyLookatplayer.TargetPosition.y, transform.parent.position.x - enemyCtrl.EnemyLookatplayer.TargetPosition.x);
                angle = initialAngle;
            }
            float x = enemyCtrl.EnemyLookatplayer.TargetPosition.x + radius * Mathf.Cos(angle);
            float y = enemyCtrl.EnemyLookatplayer.TargetPosition.y + radius * Mathf.Sin(angle);
            angle += (this.speed - 1) * Time.deltaTime;
            float t = Time.deltaTime * speed;
            transform.parent.position = Vector3.Lerp(transform.parent.position, 
            new Vector3(x, y, transform.parent.position.z), t);        
        }
        else {
            base.Moving();
            enteredCircle = false; 
        }
    }
}

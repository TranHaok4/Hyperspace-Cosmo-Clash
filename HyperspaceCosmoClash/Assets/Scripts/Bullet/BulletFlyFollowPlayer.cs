using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlyFollowPlayer : BulletFly
{
    [SerializeField] protected Transform playerPosition;
    [SerializeField] protected float speedFollow=5f;
    [SerializeField] protected float timeFollow=2f;


    protected override void OnEnable()
    {
        base.OnEnable();
        timeFollow=2f;
    }
    protected override void Fly()
    {
        if (timeFollow > 0)
        {
            Vector2 direct = (playerPosition.position - transform.parent.position).normalized;
            float rot_z = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            float timeSpeed = 5 * Time.deltaTime;
            Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
            Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
            transform.parent.rotation = currentEuler;
            transform.parent.position += transform.right * speedFollow * Time.deltaTime;
            timeFollow-=Time.deltaTime;
        }
        else base.Fly();
    }
    
}

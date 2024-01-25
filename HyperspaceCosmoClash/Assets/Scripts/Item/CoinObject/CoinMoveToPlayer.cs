using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveToPlayer : ObjecMovement
{
    [SerializeField] protected Transform playerTarget;
    [SerializeField] protected float delayTime = 1f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadPlayerTarget();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetValue();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 5;
        this.delayTime = 1;
    }

    protected virtual void LoadPlayerTarget()
    {
        if (playerTarget != null) return;
        this.playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + "LoadPlayerTarget", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if(delayTime<0)
        {
            Vector3 newpos = Vector3.Lerp(transform.position, playerTarget.position, this.speed * Time.fixedDeltaTime);
            transform.parent.position = newpos;
        }
        else delayTime -= Time.deltaTime;

    }
}

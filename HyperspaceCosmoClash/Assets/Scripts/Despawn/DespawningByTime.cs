using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawningByTime : Despawning
{
    [Header("DespawningByTime")]
    [SerializeField] protected float timeDelay = 0.1f;
    [SerializeField] protected float timer = 0f;
    protected override bool CanDespawn()
    {
        timer += Time.deltaTime;
        if(timer>=timeDelay)
        {
            timer = 0;
            return true;
        }
        return false;
    }
}

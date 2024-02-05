using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAbilityDataSO : ScriptableObject
{
    [SerializeField] protected BossAbilityName abilityName;
    protected abstract bool ActivationCondition(GameObject owner);
    public virtual IEnumerator Activate(GameObject owner)
    {
        yield return new WaitUntil(() => ActivationCondition(owner));
        DoActivate(owner);
    }
    protected abstract void DoActivate(GameObject owner);
}
public enum BossAbilityName
{
    none=0,
    CreateShield=1,
    SpawnChild=2,
}
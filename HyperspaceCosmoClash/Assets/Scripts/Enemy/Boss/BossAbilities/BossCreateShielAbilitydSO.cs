using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject class that represents a boss ability to create a shield.
/// </summary>
[CreateAssetMenu(fileName = "BossCreateShield", menuName = "ScriptableObject/BossAbilities/BossCreateShield")]

public class BossCreateShielAbilitydSO : BossAbilityDataSO
{
    [SerializeField] protected float timeDelayActive;
    [SerializeField] float lastActivationTime = 0;

    [SerializeField] protected BossShieldCtrl bossShield;
    [SerializeField] protected bool condition = true;
    protected override bool ActivationCondition(GameObject owner)
    {
        //Debug.Log(Time.time-lastActivationTime);
        if(Time.time-lastActivationTime>=timeDelayActive && condition)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Activates the boss shield ability.
    /// </summary>
    /// <param name="owner">The GameObject that owns the ability.</param>
    /// <returns>An IEnumerator used for coroutine execution.</returns>
    public override IEnumerator Activate(GameObject owner)
    {
        lastActivationTime = Time.time;
        condition = true;
        while (true)
        {
            yield return new WaitUntil(() => ActivationCondition(owner));
            DoActivate(owner);
        }
    }

    protected override void DoActivate(GameObject owner)
    {
        lastActivationTime = Time.time;
        condition = false;
        Debug.Log("Kich hoat skill Shield");
        Debug.Log(owner.transform.name);
        Transform newshield = owner.GetComponentInChildren<BossShieldCtrl>()?.transform;
        if (newshield == null)
        {
            Debug.Log("haha");
            newshield = Instantiate(bossShield.gameObject.transform, owner.transform);
        }
        newshield.parent = owner.transform;
        newshield.gameObject.SetActive(true);
        EnemyDespawn shieldDespawn = newshield.gameObject.GetComponent<EnemyCtrl>().Enemydespawn;
        if (shieldDespawn != null)
        {
            shieldDespawn.OnDespawmObjectCallBack += ResetSkill;
        }

    }
    protected virtual void ResetSkill()
    {
        lastActivationTime = Time.time;
        Debug.Log(Time.time-lastActivationTime);
        condition = true;
    }
}

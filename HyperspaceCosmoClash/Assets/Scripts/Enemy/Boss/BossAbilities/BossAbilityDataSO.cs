using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for boss ability data scriptable objects.
/// </summary>
public abstract class BossAbilityDataSO : ScriptableObject
{
    [SerializeField] protected BossAbilityName abilityName;

    /// <summary>
    /// Determines if the boss ability can be activated.
    /// </summary>
    /// <param name="owner">The owner of the boss ability.</param>
    /// <returns>True if the activation condition is met, false otherwise.</returns>
    protected abstract bool ActivationCondition(GameObject owner);

    /// <summary>
    /// Activates the boss ability.
    /// </summary>
    /// <param name="owner">The owner of the boss ability.</param>
    /// <returns>An enumerator for coroutine execution.</returns>
    public virtual IEnumerator Activate(GameObject owner)
    {
        yield return new WaitUntil(() => ActivationCondition(owner));
        DoActivate(owner);
    }

    /// <summary>
    /// Performs the activation logic for the boss ability.
    /// </summary>
    /// <param name="owner">The owner of the boss ability.</param>
    protected abstract void DoActivate(GameObject owner);
}
/// <summary>
/// Represents the different names of boss abilities.
/// </summary>
public enum BossAbilityName
{
    none=0,
    CreateShield=1,
    SpawnChild=2,
}
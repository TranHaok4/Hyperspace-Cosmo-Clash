using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class for enhancement data scriptable objects.
/// </summary>
public abstract class EnhancementDataSO : ScriptableObject
{
    [Header("Base")]
    [SerializeField] protected string discriptionEnhance;
    public string DiscriptionEnhance { get => discriptionEnhance; }
    [SerializeField] protected Sprite enhacementImage;
    [SerializeField] protected EnhancementType enhanceType ;
    public EnhancementType EnhanceType { get => enhanceType; }
    
    public event System.Action beApplyEnhance;
    /// <summary>
    /// Applies the enhancement.
    /// </summary>
    public virtual void ApplyEnhancement()
    {
        beApplyEnhance?.Invoke();
    }

    public abstract void OnApllyEnhancement(ShipCtrl shipCtrl);
    /// <summary>
    /// Gets the sprite associated with the enhancement.
    /// </summary>
    /// <returns>The sprite.</returns>
    public virtual Sprite GetSprite()
    {
        return enhacementImage;
    }

    /// <summary>
    /// Gets the description of the enhancement.
    /// </summary>
    /// <returns>The description.</returns>
    public virtual string GetDiscriptionEnhance()
    {
        return discriptionEnhance;
    }
}
/// <summary>
/// Represents the type of enhancement.
/// </summary>
public enum EnhancementType
{
    None=0,
    IncreaseHP=1,
    IncreaseShootSpeed=2,
    IncreaseDamage=3,
}

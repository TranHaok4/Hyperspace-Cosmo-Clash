using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnhancementDataSO : ScriptableObject
{
    [Header("Base")]
    [SerializeField] protected string discriptionEnhance;
    public string DiscriptionEnhance { get => discriptionEnhance; }
    [SerializeField] protected Sprite enhacementImage;
    [SerializeField] protected EnhancementType enhanceType ;
    public EnhancementType EnhanceType { get => enhanceType; }
    
    public abstract void ApplyEnhancement();

    public virtual Sprite GetSprite()
    {
        return enhacementImage;
        
    }

    public virtual string GetDiscriptionEnhance()
    {
        return discriptionEnhance;
    }
}
public enum EnhancementType
{
    None=0,
    IncreaseHP=1,
    IncreaseShootSpeed=2,
    IncreaseDamage=3,
}

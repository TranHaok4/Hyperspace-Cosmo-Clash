using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnhancementDataSO : ScriptableObject
{
    [Header("Base")]
    [SerializeField] protected string discriptionEnhance;
    public string DiscriptionEnhance { get => discriptionEnhance; }
    [SerializeField] protected Sprite enhacementImage;

    protected abstract void ApplyEnhancement();

    public virtual Sprite GetSprite()
    {
        return enhacementImage;
    }

    public virtual string GetDiscriptionEnhance()
    {
        return discriptionEnhance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for item profile scriptable objects.
/// </summary>
public abstract class ItemProfileSO : ScriptableObject
{
    [SerializeField] protected ItemName itemName;

    /// <summary>
    /// The name of the item.
    /// </summary>
    public ItemName Itemname { get => itemName; }
}

public enum ItemName
{
    none=0,
    Exp1=1,
    Exp2=2,
    Exp3=3,
    Coin=4,
}
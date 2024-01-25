using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProfileSO : ScriptableObject
{
    [SerializeField] protected ItemName itemName;
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
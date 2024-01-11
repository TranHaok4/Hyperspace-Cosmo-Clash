using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : HaroMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn Itemdespawn { get => itemDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
    }

    protected void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = this.transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ":LoadItemDespawn", gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropItem : HaroMonoBehaviour
{
    [SerializeField] protected List<ItemProfileSO> itemDropList;
    private List<ItemProfileSO> tempItemDropList;

    [SerializeField] protected List<int> itemDropRate;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropRate();
    }
    protected virtual void LoadItemDropRate()
    {
        for(int i=0;i<itemDropList.Count;i++)
        {
            itemDropRate.Add(0);
        }
    }


    protected virtual void OnValidate()
    {
        tempItemDropList = new List<ItemProfileSO>(itemDropList);
        //Debug.Log(tempItemDropList.Count);
    }
    protected override void Reset()
    {
        itemDropList = new List<ItemProfileSO>(tempItemDropList);
        base.Reset();
    }

    public virtual void Dropping()
    {
        DropItem();
    }
    protected virtual void DropItem()
    {
        string item_name = GetItemDrop();
        if (item_name == ItemName.none.ToString()) return;
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform itemObject = ItemSpawner.Instance.Spawn(item_name, hitPos, hitRot);
        itemObject.gameObject.SetActive(true);
    }
    protected virtual string GetItemDrop()
    {
        int dropchance = Random.Range(0, 100);
        //Debug.Log("dropchance:"+dropchance);
        List<int> itemdropIndex = new List<int>();
        for(int i=0;i<itemDropList.Count;i++)
        {
            if(dropchance < itemDropRate[i])
            {
                itemdropIndex.Add(i);
            }
        }
        if(itemdropIndex.Count==0)
        {
            return ItemName.none.ToString() ;
        }
        int tmpindex = Random.Range(0, itemdropIndex.Count - 1);
        //Debug.Log("tmpindex:"+tmpindex);
        int randomIndexItem = itemdropIndex[tmpindex];
        //Debug.Log("randomIndexItem:"+randomIndexItem);
        return itemDropList[randomIndexItem].Itemname.ToString();
    }
}


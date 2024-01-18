using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHUD : HaroMonoBehaviour
{
    [SerializeField] protected List<Transform> childUIs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadChildUIs();
    }

    protected virtual void LoadChildUIs()
    {
        if (this.childUIs.Count > 0) return;
        foreach(Transform child in transform)
        {
            childUIs.Add(child);
        }
    }
}

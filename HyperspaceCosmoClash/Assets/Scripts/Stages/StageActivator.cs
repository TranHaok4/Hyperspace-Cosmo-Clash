using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StageActivator : HaroMonoBehaviour
{
    [SerializeField] protected BoxCollider2D collider2d;
    [SerializeField] protected StageDataSO stageData;
    [SerializeField] protected int stageId;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<BoxCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.transform.parent.GetComponent<ShipCtrl>()) return;
        StageSpawnerManager.Instance.SetCurrentStageData(stageData,stageId);
        Destroy(gameObject);

    }
}

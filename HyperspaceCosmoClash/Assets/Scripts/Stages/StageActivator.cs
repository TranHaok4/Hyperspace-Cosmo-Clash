using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StageActivator : HaroMonoBehaviour
{
    [SerializeField] protected BoxCollider2D collider2d;
    [SerializeField] protected StageDataSO stageData;
    [SerializeField] protected int stageId;

    /// <summary>
    /// Loads the required components and initializes the collider.
    /// </summary>
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    /// <summary>
    /// Loads the collider component if it is not already assigned.
    /// </summary>
    protected virtual void LoadCollider()
    {
        if (this.collider2d != null) return;
        this.collider2d = GetComponent<BoxCollider2D>();
        this.collider2d.isTrigger = true;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    /// <summary>
    /// Called when a 2D collider enters the trigger.
    /// </summary>
    /// <param name="collision">The collider that entered the trigger.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.transform.parent.GetComponent<ShipCtrl>()) return;
        StageSpawnerManager.Instance.SetCurrentStageData(stageData, stageId);
        ObstacleStageManager.Instance.TurnOnObstacleStage(stageId);
        Destroy(gameObject);
    }
}

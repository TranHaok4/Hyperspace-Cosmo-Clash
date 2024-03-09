using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for making an enemy object look at the player.
/// It inherits from the ObjectLookAtTarget class.
/// </summary>
public class EnemyLookAtPlayer : ObjectLookAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected GameObject player;
    [SerializeField] protected bool isDisplayLine=false;
    [SerializeField] protected LineRenderer lineRenderer;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        LoadEnemyCtrl();
        lineRenderer = GetComponent<LineRenderer>();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ":LoadPlayer", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl", gameObject);
    }
    protected virtual void GetPlayerPosition()
    {
        if (this.player == null) return;
        this.targetPosition = this.player.transform.position;
        this.targetPosition.z = 0;
    }
    protected override void Start()
    {
        base.Start();
        if(lineRenderer!=null)
        {
            enemyCtrl.Objectshooting.onShootingCallBack+=TurnOffLineFewSeconds;
        }
    }
    protected virtual void Update()
    {
        if (isDisplayLine && targetPosition != null)
        {
            Vector3 direction = targetPosition - transform.position;
            Vector3 position = transform.position + direction * (lineRenderer.positionCount);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + 5*direction);
        }
    }
    protected virtual void TurnOffLineFewSeconds()
    {
        StartCoroutine(TurnOffLine());
    }

    IEnumerator TurnOffLine()
    {
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(0.75f);
        lineRenderer.enabled = true;
    }


}

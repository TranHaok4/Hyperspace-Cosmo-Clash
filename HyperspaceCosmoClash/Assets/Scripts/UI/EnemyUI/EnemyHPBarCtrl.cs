using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBarCtrl : HaroMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected HPBarType hpBarType;

    private void OnValidate()
    {
        this.transform.name = hpBarType.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFollowTarget();
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.Log(transform.name+"LoadFollowTarget", gameObject);
    }
    public virtual void SetEnemyCtrl(EnemyCtrl enemy_Ctrl)
    {
        enemyCtrl = enemy_Ctrl;
        if(followTarget!=null)
        {
            followTarget.SetTarget(enemyCtrl.transform);
        }
    }
}

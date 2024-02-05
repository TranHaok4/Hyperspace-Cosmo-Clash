using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilities : HaroMonoBehaviour
{
    [SerializeField] protected BossCtrl bossCtrl;
    [SerializeField] protected List<BossAbilityDataSO> abilites;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossCtrl();
    }
    protected virtual void LoadBossCtrl()
    {
        if (this.bossCtrl != null) return;
        this.bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.Log(transform.name + "LoadBossCtrl", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        foreach(BossAbilityDataSO ability in abilites)
        {
            if (ability != null)
            {
                StartCoroutine(ability.Activate(bossCtrl.gameObject));
            }
        }
    }

}

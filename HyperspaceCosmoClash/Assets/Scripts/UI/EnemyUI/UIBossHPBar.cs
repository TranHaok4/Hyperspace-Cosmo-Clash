using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHPBar : BaseUIComponent
{
    [SerializeField] protected Slider HpBar;
    protected override void Start()
    {
        base.Start();
        this.SetUpUIlogic();
        this.gameObject.SetActive(false);

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossHPBar();

    }
    protected virtual void LoadBossHPBar()
    {
        if (this.HpBar != null) return;
        this.HpBar = this.GetComponent<Slider>();
        Debug.Log(transform.name + ":LoadBossHPBar", gameObject);
    }
    protected virtual void UpdateBossState(bool state)
    {
        this.gameObject.SetActive(state);
    }
    protected virtual void UpdateBossHP(int hp,int maxhp)
    {
        this.HpBar.value = (float)hp / maxhp;
    }
    public override void SetUpUIlogic()
    {
        BossStatsNotificater.Instance.updateBossState += UpdateBossState;
        BossStatsNotificater.Instance.updateBossHP += UpdateBossHP;
    }
}

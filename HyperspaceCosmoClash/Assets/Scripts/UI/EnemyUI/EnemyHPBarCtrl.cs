using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPBarCtrl : HaroMonoBehaviour
{
    //[SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected HPBarType hpBarType;
    [SerializeField] protected Slider hpSlider;

    private void OnValidate()
    {
        this.transform.name = hpBarType.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFollowTarget();
        this.LoadHpSlider();

    }
    protected virtual void LoadHpSlider()
    {
        if (this.hpSlider != null) return;
        this.hpSlider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + "LoadHpSlider", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponent<FollowTarget>();
        Debug.Log(transform.name+"LoadFollowTarget", gameObject);
    }
    protected virtual void ChangeHPBar(int hp,int maxhp)
    {
        hpSlider.value = (float)hp / maxhp;
        if (hp == maxhp && hpBarType!=HPBarType.BossHPBar) this.hpSlider.gameObject.SetActive(false);
        Debug.Log(this.gameObject.activeSelf);
        if(hpBarType!=HPBarType.BossHPBar && this.gameObject.activeSelf!=false && hp!=maxhp)
        {
            StartCoroutine(TurnOnfHPAfterTime());
        }

    }
    protected IEnumerator TurnOnfHPAfterTime()
    {
        this.hpSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        this.hpSlider.gameObject.SetActive(false);
        Debug.Log("change");

    }
    //protected virtual void DespawnHPBar()
    //{
    //    //Debug.Log("da bi despawn");

    //    HPBarSpawner.Instance.Despawn(this.transform);
    //}
    public virtual void SetEnemyCtrl(EnemyCtrl enemy_Ctrl)
    {
        //enemyCtrl = enemy_Ctrl;
        enemy_Ctrl.EnemyDamagereceiver.updateEnemyHP += ChangeHPBar;
        EnemyDespawn newenemydespawn = enemy_Ctrl.Enemydespawn;
        if (newenemydespawn != null)
        {
            newenemydespawn.OnDespawmObjectCallBack += DespawnHPBar;
        }
        else
        {
            Debug.LogWarning("EnemyDespawn is not set for this enemy.");
        }
        if (followTarget!=null)
        {
            followTarget.SetTarget(enemy_Ctrl.transform);
        }

        void DespawnHPBar()
        {
            HPBarSpawner.Instance.Despawn(this.transform);
            newenemydespawn.OnDespawmObjectCallBack -= DespawnHPBar;
        }
    }
}

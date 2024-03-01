using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CreateShieldAbilitySO", menuName = "ScriptableObject/ShipAbilities/CreateShieldAbilitySO")]

public class CreateShieldAbilitySO : AbilityStatSO
{
    [SerializeField] protected Transform shieldPrefab;
    [SerializeField] protected bool isShieldActive;


    public override void ResetSkill()
    {
        base.ResetSkill();
        isShieldActive=false;
    }
    protected virtual void CheckCondition()
    {
        isShieldActive=false;
    }
    public override void ActiveSkill(ShipCtrl shipCtrl)
    {
        if(abilityState==AbilityState.CoolDown || isShieldActive==true)
        {
            return;
        }
        Vector3 spawnpos=shipCtrl.transform.position;
        Quaternion spawnrot=shipCtrl.transform.rotation;
        Transform shield=Instantiate(shieldPrefab,spawnpos,spawnrot);
        shield.parent=shipCtrl.transform;
        ShipShieldCtrl shipShieldCtrl=shield.GetComponent<ShipShieldCtrl>();
        shipShieldCtrl.ShipShielddespawn.onShieldDespawnCallBack+=CheckCondition;
        isShieldActive=true;
        shipCtrl.StartCoroutine(Cooldowning());
    }
    protected override IEnumerator Cooldowning()
    {
        coolDownTimer = coolDownDelay;
        abilityState = AbilityState.CoolDown;
        NotifySkillState();
        while(coolDownTimer>=0)
        {
            while(isShieldActive==true)
            {
                yield return null;
            }
            coolDownTimer -= Time.deltaTime;
            NotifySkillCoolDown();
            yield return null;
        }
        abilityState = AbilityState.Ready;
        NotifySkillState();
    }
}

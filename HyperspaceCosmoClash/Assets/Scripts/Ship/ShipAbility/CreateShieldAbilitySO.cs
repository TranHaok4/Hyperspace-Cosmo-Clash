using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CreateShieldAbilitySO", menuName = "ScriptableObject/ShipAbilities/CreateShieldAbilitySO")]

public class CreateShieldAbilitySO : AbilityStatSO
{
    [SerializeField] protected Transform shieldPrefab;

    public override void ActiveSkill(ShipCtrl shipCtrl)
    {
        if(abilityState==AbilityState.CoolDown)
        {
            return;
        }
        Vector3 spawnpos=shipCtrl.transform.position;
        Quaternion spawnrot=shipCtrl.transform.rotation;
        Transform shield=Instantiate(shieldPrefab,spawnpos,spawnrot);
        shield.parent=shipCtrl.transform;
        shipCtrl.StartCoroutine(Cooldowning());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnMissleAbilitySO", menuName = "ScriptableObject/ShipAbilities/SpawnMissleAbilitySO", order = 1)]
public class SpawnMissleAbility : AbilityStatSO
{
    [SerializeField] protected int numberOFMissle;
    [SerializeField] protected GameObject misslePrefab;


    public override void ActiveSkill(ShipCtrl shipCtrl)
    {
        if(abilityState==AbilityState.CoolDown) return;
        shipCtrl.StartCoroutine(SpawnMissle(shipCtrl));
        shipCtrl.StartCoroutine(Cooldowning());
    }
    
    protected IEnumerator SpawnMissle(ShipCtrl shipCtrl)
    {
        for (int i = 0; i < numberOFMissle; i++)
        {
            GameObject missle = Instantiate(misslePrefab, shipCtrl.transform.position, shipCtrl.transform.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }
}

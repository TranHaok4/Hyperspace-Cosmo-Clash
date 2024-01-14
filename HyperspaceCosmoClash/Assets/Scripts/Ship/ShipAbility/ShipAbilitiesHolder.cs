using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAbilitiesHolder : HaroMonoBehaviour
{
    [SerializeField] BaseAbility abilityIndex1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityIndex();
    }
    protected void LoadAbilityIndex()
    {
        List<BaseAbility> abilitiesIndex = new List<BaseAbility>();
        foreach(Transform obj in transform)
        {
            abilitiesIndex.Add(obj.GetComponent<BaseAbility>());
        }
        abilityIndex1 = abilitiesIndex[0];
    }
    private void Update()
    {
        CheckAndUseSkill(InputManager.Instance.OnButtonSkill1);
    }
    protected void CheckAndUseSkill(bool buttonskill)
    {
        if (!abilityIndex1.CheckAbilityisReady())
        {
            abilityIndex1.CoolDowning();
            return;
        }

        if (!buttonskill) return;

        abilityIndex1.ActiveSkill();
        abilityIndex1.StartCoolDown();
    }
}

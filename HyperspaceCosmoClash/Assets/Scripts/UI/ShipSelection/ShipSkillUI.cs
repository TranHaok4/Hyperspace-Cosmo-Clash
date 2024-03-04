using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSkillUI : UIShipSelectionBase
{
    [SerializeField] protected Image shipSkillSprite;
    [SerializeField] [Range(1, 2)] protected int abilityIndex;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShipSkillSprite();
    }
    protected virtual void LoadShipSkillSprite()
    {
        if(shipSkillSprite!=null) return;
        shipSkillSprite = this.GetComponentInChildren<Image>();
        Debug.Log(transform.name + " LoadShipSkillSprite: ",gameObject);
    }

    public override void SetUpUIlogic(ShipProfileSO shipProfile)
    {
        if(abilityIndex == 1)
            shipSkillSprite.sprite = shipProfile.Ability1.SkillIcon;
        else
            shipSkillSprite.sprite = shipProfile.Ability2.SkillIcon;
    }

    public override void SetUpUIlogic(){} // no overide needed
}

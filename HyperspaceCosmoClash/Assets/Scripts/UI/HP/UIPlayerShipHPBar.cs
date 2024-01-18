using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerShipHPBar : BaseUIComponent
{
    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (HPShipPlayerNotificater.Instance == null)
        {
            yield return null;
        }
        HPShipPlayerNotificater.Instance.updateHPPlayerShip += UpdateHealthBar;
    }

    [SerializeField] protected Slider shipHPbar;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipHPBar();
           
    }
    protected virtual void LoadShipHPBar()
    {
        if (this.shipHPbar != null) return;
        this.shipHPbar = this.GetComponent<Slider>();
        Debug.Log(transform.name + ":LoadShipHPBar", gameObject);
    }
    protected virtual void UpdateHealthBar(int hp,int maxhp)
    {
        //Debug.Log("da tiep tuc hp");
        this.shipHPbar.value = (float)hp / maxhp;
    }
}

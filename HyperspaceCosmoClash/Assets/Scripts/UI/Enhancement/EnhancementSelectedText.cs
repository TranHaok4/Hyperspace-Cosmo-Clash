using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancementSelectedText : HaroMonoBehaviour
{
    [SerializeField] protected Text selectedEnhanceText;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectedEnhanceText();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (this.selectedEnhanceText != null) selectedEnhanceText.text = "Pick an enhancement";
    }
    protected virtual void LoadSelectedEnhanceText()
    {
        if (this.selectedEnhanceText != null) return;
        this.selectedEnhanceText = this.GetComponent<Text>();
        Debug.Log(transform.name + "LoadSelectedEnhanceText", gameObject);
    }

    public virtual void ChangeSelectedEnhance(string changetext)
    {
        this.selectedEnhanceText.text = changetext;
    }
}

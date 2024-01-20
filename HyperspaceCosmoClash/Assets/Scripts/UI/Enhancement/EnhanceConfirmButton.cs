using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceConfirmButton : HaroMonoBehaviour
{
    [SerializeField] protected Button confirmButton;
    public Button ConfirmButton { get => confirmButton; }

    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadConfirmButton();
    }
    protected virtual void LoadConfirmButton()
    {
        if (this.confirmButton != null) return;
        this.confirmButton = this.GetComponent<Button>();
        Debug.Log(transform.name + "LoadConfirmButton", gameObject);
    }
}

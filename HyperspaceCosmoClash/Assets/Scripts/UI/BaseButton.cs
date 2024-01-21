using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseButton : HaroMonoBehaviour
{
    [SerializeField] protected Button button;
    public Button _Button { get => button; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = this.GetComponent<Button>();
        Debug.Log(transform.name + "LoadButton", gameObject);
    }
}

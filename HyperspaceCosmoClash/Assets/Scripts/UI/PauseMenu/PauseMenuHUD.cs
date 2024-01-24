using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHUD : BaseHUD
{
    [SerializeField] protected UIPauseGamePanel uiPauseGamePanel;
    [SerializeField] protected BaseButton pauseGameButton;

    protected override void Start()
    {
        base.Start();
        pauseGameButton._Button.onClick.AddListener(uiPauseGamePanel.TurnOn);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPauseGamePanel();
        this.LoadPauseGameButton();
    }
    protected virtual void LoadPauseGamePanel()
    {
        if (this.uiPauseGamePanel != null) return;
        this.uiPauseGamePanel = this.GetComponentInChildren<UIPauseGamePanel>();
        Debug.Log(transform.name + "LoadPauseGamePanel", gameObject);
    }
    protected virtual void LoadPauseGameButton()
    {
        if (this.pauseGameButton != null) return;
        this.pauseGameButton = this.GetComponentInChildren<BaseButton>();
        Debug.Log(transform.name + "LoadPauseGameButton", gameObject);
    }
}

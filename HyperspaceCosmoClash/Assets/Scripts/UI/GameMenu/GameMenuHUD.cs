using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuHUD : HaroMonoBehaviour
{
    [SerializeField] protected BaseButton startButton;
    [SerializeField] protected BaseButton exitButton;
    [SerializeField] protected BaseButton optionButton;
    [SerializeField] protected BaseButton creditButton;

    protected override void Start()
    {
        base.Start();
        InitButtonAction();
    }
    protected virtual void InitButtonAction()
    {
        startButton._Button.onClick.AddListener(()=>GameLevelManager.Instance.LoadScene("ShipSelectionScene"));
        exitButton._Button.onClick.AddListener(GameLevelManager.Instance.ExitGame);
    }
}

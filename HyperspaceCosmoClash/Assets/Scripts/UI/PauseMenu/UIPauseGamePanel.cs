using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseGamePanel : BaseUIComponent
{
    [SerializeField] protected BaseButton mainMenuButton;
    [SerializeField] protected BaseButton continueGameButton;


    protected override void Start()
    {
        base.Start();
        this.gameObject.SetActive(false);
        mainMenuButton._Button.onClick.AddListener(() => GameLevelManager.Instance.LoadScene("GameMenuScene"));
        continueGameButton._Button.onClick.AddListener(TurnOff);
    }
    public override void SetUpUIlogic()
    {
        throw new System.NotImplementedException();
    }
    protected virtual void TurnOff()
    {
        if(this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
    public virtual void TurnOn()
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnhancementPanel : BaseUIComponent
{
    [SerializeField] protected Image enhancementBoard;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnhancementBoard();
    }

    protected virtual void LoadEnhancementBoard()
    {
        if (this.enhancementBoard != null) return;
        this.enhancementBoard = this.GetComponent<Image>();
        Debug.Log(transform.name + ":LoadEnhancementBoard", gameObject);
    }
    protected override void Awake()
    {
        StartCoroutine(WaitForConditionThenExecute());
    }
    protected override IEnumerator WaitForConditionThenExecute()
    {
        //Debug.Log("0k");

        while (LevelExpShipPlayerNotificater.Instance == null)
        {
            yield return null;
        }
        LevelExpShipPlayerNotificater.Instance.updateLevelPlayerShip += TurnOnOffEnhancementBoard;
        this.gameObject.SetActive(false);
    }
    protected virtual void TurnOnOffEnhancementBoard(int currentlevel)
    {
        //Debug.Log(currentlevel);
        if (currentlevel <= 1) return;
        //Debug.Log("haha");
        if (!gameObject.activeSelf)
        {
           // Debug.Log("haha");
            this.gameObject.SetActive(true);
        }
    }
}

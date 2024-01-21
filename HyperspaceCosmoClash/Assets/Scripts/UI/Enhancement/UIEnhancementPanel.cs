using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnhancementPanel : BaseUIComponent
{
    [SerializeField] protected Image enhancementBoard;
    [SerializeField] protected List<EnhancementBox> iconBoxs;
    [SerializeField] protected EnhanceConfirmButton confirmButton;
    [SerializeField] protected EnhancementSelectedText enhancementSelectedText;


    protected override void Start()
    {
        base.Start();
        this.InitlizeComponent();
    }
    protected virtual void InitlizeComponent()
    {
        foreach (EnhancementBox box in iconBoxs)
        {
            box.beClicked += enhancementSelectedText.ChangeSelectedEnhance;
            confirmButton._Button.onClick.AddListener(box.OnBeSelected);
        }
            

        confirmButton._Button.onClick.AddListener(TurnOffEnhacementBoard);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnhancementBoard();
        this.LoadConfirmButton();
        this.LoadEnhancementSelectedText();
        this.LoadIconBoxs();
    }
    protected virtual void LoadIconBoxs()
    {
        if (this.iconBoxs.Count != 0) return;
        foreach(Transform obj in transform)
        {
            EnhancementBox box=obj.transform.GetComponent<EnhancementBox>();
            if (box!=null)
            {
                this.iconBoxs.Add(box);
            }
        }
        Debug.Log(transform.name + ":LoadIconBoxs", gameObject);

    }

    protected virtual void LoadEnhancementSelectedText()
    {
        if (this.enhancementSelectedText != null) return;
        this.enhancementSelectedText = this.GetComponentInChildren<EnhancementSelectedText>();
        Debug.Log(transform.name + ":LoadEnhancementSelectedText", gameObject);
    }

    protected virtual void LoadEnhancementBoard()
    {
        if (this.enhancementBoard != null) return;
        this.enhancementBoard = this.GetComponent<Image>();
        Debug.Log(transform.name + ":LoadEnhancementBoard", gameObject);
    }
    protected virtual void LoadConfirmButton()
    {
        if (this.confirmButton != null) return;
        this.confirmButton = this.GetComponentInChildren<EnhanceConfirmButton>();
        Debug.Log(transform.name + ":LoadConfirmButton", gameObject);
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
        LevelExpShipPlayerNotificater.Instance.updateLevelPlayerShip += TurnOnEnhancementBoard;
        this.gameObject.SetActive(false);
    }
    protected virtual void TurnOnEnhancementBoard()
    {
        if (!gameObject.activeSelf)
        {
            // Debug.Log("haha");
            this.gameObject.SetActive(true);
        }
    }
    protected virtual void TurnOnEnhancementBoard(int currentlevel)
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

    protected virtual void TurnOffEnhacementBoard()
    {
        if (gameObject.activeSelf)
        {
            // Debug.Log("haha");
            this.gameObject.SetActive(false);
        }
    }
}

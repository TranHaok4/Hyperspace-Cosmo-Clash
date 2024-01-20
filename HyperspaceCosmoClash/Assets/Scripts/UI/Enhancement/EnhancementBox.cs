using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class EnhancementBox : HaroMonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected EnhancementDataSO enhanceData;
    [SerializeField] protected Image enhanceIcon;
    [SerializeField] protected Image borderSelected;

    public event UnityAction<string> beClicked;
    protected static EnhancementBox currentlySelectedBox;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (this.enhanceData != null) this.enhanceIcon.sprite = enhanceData.GetSprite();
        if (this.borderSelected != null) this.borderSelected.gameObject.SetActive(false);
    }
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnhanceIcon();
        this.LoadborderSelected();
    }
    protected virtual void LoadEnhanceIcon()
    {
        if (this.enhanceIcon != null) return;
        this.enhanceIcon = this.GetComponent<Image>();
        Debug.Log(transform.name + "LoadEnhanceIcon", gameObject);
    }
    protected virtual void LoadborderSelected()
    {
        if (this.borderSelected != null) return;
        Transform borderTransform = transform.Find("border");
        if (borderTransform == null) return;
        this.borderSelected = borderTransform.GetComponent<Image>();
        Debug.Log(transform.name + "LoadborderSelected", gameObject);
    }
    public string GetEnhancementDiscription()
    {
        return enhanceData.DiscriptionEnhance;
    }

    public virtual void OnBeClicked(string text)
    {
        if(beClicked!=null)
        {
            beClicked(text);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(currentlySelectedBox !=null && currentlySelectedBox!=this)
        {
            currentlySelectedBox.TurnOffBorderSelected();
        }
        currentlySelectedBox = this;
        OnBeClicked(enhanceData.DiscriptionEnhance);
        TurnOnBorderSelected();
    }
    public virtual void OnBeSelected()
    {
        if(currentlySelectedBox!=null && currentlySelectedBox==this)
        {
            currentlySelectedBox.enhanceData.ApplyEnhancement();
        }
    }
    protected virtual void TurnOnBorderSelected()
    {
        borderSelected.gameObject.SetActive(true);
    }
    protected virtual void TurnOffBorderSelected()
    {
        borderSelected.gameObject.SetActive(false);
    }

}

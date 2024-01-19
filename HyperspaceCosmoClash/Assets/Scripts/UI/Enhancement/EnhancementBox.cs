using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class EnhancementBox : HaroMonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected EnhancementDataSO enhanceData;
    [SerializeField] protected Image enhanceIcon;

    public event UnityAction<string> beClicked;
    protected override void OnEnable()
    {
        base.OnEnable();
        if (this.enhanceData != null) this.enhanceIcon.sprite = enhanceData.GetSprite();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnhanceIcon();
    }
    protected virtual void LoadEnhanceIcon()
    {
        if (this.enhanceIcon != null) return;
        this.enhanceIcon = this.GetComponent<Image>();
        Debug.Log(transform.name + "LoadEnhanceIcon", gameObject);
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
        OnBeClicked(enhanceData.DiscriptionEnhance);
    }
}

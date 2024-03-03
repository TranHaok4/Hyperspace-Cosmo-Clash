using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages player input and provides access to input values.
/// </summary>
public class InputManager : HaroMonoBehaviour
{

    [SerializeField]protected float horinzontalValue;
    public float HorizontalValue { get => horinzontalValue; }
    [SerializeField] protected float verticalValue;
    public float VerticalValue { get => verticalValue; }

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    [SerializeField] protected bool onButtonSkill1;
    public bool OnButtonSkill1 { get => onButtonSkill1; }
    [SerializeField] protected bool onButtonSkill2;
    public bool OnButtonSkill2 { get => onButtonSkill2; }
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("only 1 InputManager");
        InputManager.instance = this;
    }
    protected virtual void Update()
    {
        this.GetMouseDown();
        this.GetOnButtonSkill1();
        this.GetOnButtonSkill2();
    }
    protected virtual void FixedUpdate()
    {
        this.GetMove4Direction();
        this.GetMousePos();
    }
    /// <summary>
    /// Event that is triggered when the movement state changes.
    /// </summary>
    public event UnityAction<bool> OnMovementChange;

    protected void GetMove4Direction()
    {
        float oldHorizontal = horinzontalValue;
        float oldVertical = verticalValue;

        horinzontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        if (OnMovementChange != null)
        {
            OnMovementChange(!(horinzontalValue == 0f && verticalValue == 0f));
        }
    }
    protected void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public UnityAction<int> OnFiringChange;
    protected void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
        OnFiringChange(this.onFiring>0?1:0);
    }
    public UnityAction<int> OnButtonSkill1Change;
    protected void GetOnButtonSkill1()
    {
        this.onButtonSkill1=Input.GetKeyDown(KeyCode.Mouse1)?true:false;
        if(OnButtonSkill1Change!=null)
        {
            OnButtonSkill1Change(this.onButtonSkill1?1:0);
        }
        /*
        if (onButtonSkill1)
        {
            Debug.Log("da bam chuot phai");
        }*/
    }
    public UnityAction<int> OnButtonSkill2Change;
    protected void GetOnButtonSkill2()
    {
        this.onButtonSkill2=Input.GetKeyDown(KeyCode.Q)?true:false;
        if(OnButtonSkill2Change!=null)
        {
            OnButtonSkill2Change(this.onButtonSkill2?1:0);
        }
        /*
        if (onButtonSkill1)
        {
            Debug.Log("da bam chuot phai");
        }*/
    }
}

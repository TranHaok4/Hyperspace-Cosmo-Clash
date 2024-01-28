using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : HaroMonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

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
    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("only 1 InputManager");
        InputManager.instance = this;
    }
    protected virtual void Update()
    {
        this.GetMouseDown();
        this.GetOnButtonSkill1();
    }
    protected virtual void FixedUpdate()
    {
        this.GetMove4Direction();
        this.GetMousePos();
    }
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
    protected void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected void GetOnButtonSkill1()
    {
        this.onButtonSkill1=Input.GetKeyDown(KeyCode.Mouse1)?true:false;
        /*
        if (onButtonSkill1)
        {
            Debug.Log("da bam chuot phai");
        }*/
    }
}

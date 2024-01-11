using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected override void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("only 1 InputManager");
        InputManager.instance = this;
    }
    protected virtual void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void FixedUpdate()
    {
        this.GetMove4Direction();
        this.GetMousePos();
    }
    protected void GetMove4Direction()
    {
        horinzontalValue= Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
    }
    protected void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecMovement : HaroMonoBehaviour
{
    [Header("ObjectMovement")]
    [SerializeField] protected float speed = 0.01f;
    public float Speed { get => speed; }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

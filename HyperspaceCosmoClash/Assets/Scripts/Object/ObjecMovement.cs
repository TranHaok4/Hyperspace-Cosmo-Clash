using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecMovement : HaroMonoBehaviour
{
    [SerializeField] protected float speed = 0.01f;
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

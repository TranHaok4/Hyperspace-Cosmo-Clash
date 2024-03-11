using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a script that allows the parent object to fly in a specified direction with a given move speed.
/// </summary>
public class ParentFly : HaroMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;

    void Update()
    {
        Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}

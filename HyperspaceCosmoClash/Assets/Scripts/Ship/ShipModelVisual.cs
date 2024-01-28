using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModelVisual : HaroMonoBehaviour
{
    [SerializeField] protected ParticleSystem trailVFX;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrailVFX();
    }

    protected virtual void LoadTrailVFX()
    {
        if (this.trailVFX != null) return;
        this.trailVFX = GetComponentInChildren<ParticleSystem>();
        Debug.Log(transform.name + "LoadTrailVFX", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        InputManager.Instance.OnMovementChange += HandleMovementChange;

    }

    //protected override void OnDisable()
    //{
    //    InputManager.Instance.OnMovementChange -= HandleMovementChange;
    //}

    private void HandleMovementChange(bool isMoving)
    {
        if (trailVFX != null)
        {
            trailVFX.gameObject.SetActive(isMoving);
        }
    }
}

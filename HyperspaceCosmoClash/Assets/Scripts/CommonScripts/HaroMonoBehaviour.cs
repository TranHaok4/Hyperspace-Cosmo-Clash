using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all HaroMonoBehaviours.
/// </summary>
public abstract class HaroMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// Called when the script is loaded or reset in the Unity editor.
    /// </summary>
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    protected virtual void Start()
    {
        // For override
    }

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    /// <summary>
    /// Method to load components. Override this method to load specific components.
    /// </summary>
    protected virtual void LoadComponents()
    {
        // For override
    }

    /// <summary>
    /// Method to reset values. Override this method to reset specific values.
    /// </summary>
    protected virtual void ResetValue()
    {
        // For override
    }

    /// <summary>
    /// Called when the object becomes enabled and active.
    /// </summary>
    protected virtual void OnEnable()
    {
        // For override
    }

    /// <summary>
    /// Called when the object becomes disabled or inactive.
    /// </summary>
    protected virtual void OnDisable()
    {
        // For override
    }
}

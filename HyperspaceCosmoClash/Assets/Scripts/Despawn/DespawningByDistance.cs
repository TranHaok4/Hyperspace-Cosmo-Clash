using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a class that handles despawning of game objects based on distance from the camera.
/// </summary>
public class DespawningByDistance : Despawning
{
    [Header("DespawnByDistance")]
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    /// <summary>
    /// Loads the required components for despawning by distance.
    /// </summary>
    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    /// <summary>
    /// Loads the main camera if it is not already assigned.
    /// </summary>
    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    /// <summary>
    /// Determines whether the game object can be despawned based on its distance from the camera.
    /// </summary>
    /// <returns>True if the game object can be despawned, false otherwise.</returns>
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}

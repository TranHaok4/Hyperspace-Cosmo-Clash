using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a collection of spawn points in a game.
/// </summary>
public class SpawnPoints : HaroMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    
    /// <summary>
    /// Gets the list of spawn points.
    /// </summary>
    public List<Transform> Points { get => points; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            points.Add(point);
        }
    }

    /// <summary>
    /// Gets a random spawn point from the list.
    /// </summary>
    /// <returns>A random spawn point.</returns>
    public virtual Transform GetRandomPoint()
    {
        int randIndex = Random.Range(0, this.points.Count);
        return this.points[randIndex];
    }
}

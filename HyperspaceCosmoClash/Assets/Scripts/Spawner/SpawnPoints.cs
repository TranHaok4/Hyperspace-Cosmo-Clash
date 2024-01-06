using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : HaroMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

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

    public virtual Transform GetRandomPoint()
    {
        int randIndex = Random.Range(0, this.points.Count);
        return this.points[randIndex];
    }
}

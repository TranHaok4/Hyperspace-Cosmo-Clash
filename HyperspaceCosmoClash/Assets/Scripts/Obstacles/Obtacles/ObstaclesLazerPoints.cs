using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLazerPoints : HaroMonoBehaviour
{
    [SerializeField] protected Transform position1;
    [SerializeField] protected Transform position2;

    public Transform Position1 { get => position1; }
    public Transform Position2 { get => position2; }
}

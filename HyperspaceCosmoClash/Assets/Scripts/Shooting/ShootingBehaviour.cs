using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingBehaviour : ScriptableObject
{
    public abstract void Shoot(MonoBehaviour caller,Transform shooterTransform, TypeBullet typeBullet);

}


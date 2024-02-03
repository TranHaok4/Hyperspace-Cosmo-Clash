using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingBehaviour : ScriptableObject
{
    public abstract void Shoot(Transform shooterTransform, TypeBullet typeBullet);

}


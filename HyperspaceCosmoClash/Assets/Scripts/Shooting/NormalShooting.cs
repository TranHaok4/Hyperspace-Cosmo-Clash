using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a shooting behavior that spawns and activates a normal bullet.
/// </summary>
[CreateAssetMenu(fileName = "NormalShooting", menuName = "ScriptableObject/ShootingBehaviour/NormalShooting")]
public class NormalShooting : ShootingBehaviour
{
    /// <summary>
    /// Spawns and activates a bullet of the specified type at the given position and rotation.
    /// </summary>
    /// <param name="caller">The MonoBehaviour that called the Shoot method.</param>
    /// <param name="shooterTransform">The transform of the shooter.</param>
    /// <param name="typeBullet">The type of bullet to spawn.</param>
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        Vector3 spawnPos = shooterTransform.position;
        Quaternion rotation = shooterTransform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
        newBullet.gameObject.SetActive(true);
    }
}
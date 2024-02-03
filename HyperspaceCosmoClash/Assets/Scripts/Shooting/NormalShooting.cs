using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalShooting", menuName = "ScriptableObject/ShootingBehaviour/NormalShooting")]
public class NormalShooting : ShootingBehaviour
{
    public override void Shoot(Transform shooterTransform, TypeBullet typeBullet)
    {
        Vector3 spawnPos = shooterTransform.position;
        Quaternion rotation = shooterTransform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
        newBullet.gameObject.SetActive(true);
    }
}
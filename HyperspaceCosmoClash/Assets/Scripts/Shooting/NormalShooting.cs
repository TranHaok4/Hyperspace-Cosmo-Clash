using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a shooting behavior that spawns and activates a normal bullet.
/// </summary>
[CreateAssetMenu(fileName = "NormalShooting", menuName = "ScriptableObject/ShootingBehaviour/NormalShooting")]
public class NormalShooting : ShootingBehaviour
{
    [SerializeField] protected int numberOfBullet;
    [SerializeField] protected float widthRangeShooting;
    /// <summary>
    /// Spawns and activates a bullet of the specified type at the given position and rotation.
    /// </summary>
    /// <param name="caller">The MonoBehaviour that called the Shoot method.</param>
    /// <param name="shooterTransform">The transform of the shooter.</param>
    /// <param name="typeBullet">The type of bullet to spawn.</param>
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {

        float range = widthRangeShooting/(numberOfBullet);
        for(int i=0;i<numberOfBullet;i++)
        {
            // Tìm vector vuông góc
            float rotation = -caller.transform.eulerAngles.z+90;
            Vector3 direction = new Vector3(Mathf.Sin(rotation * Mathf.Deg2Rad), Mathf.Cos(rotation * Mathf.Deg2Rad));
            Vector3 perpendicularDirection = new Vector3(-direction.y, direction.x);

            float offSet = -widthRangeShooting / 2 + i * range;
            Vector3 positionOffset = offSet * perpendicularDirection;

            // Tính toán randomPosition
            Vector3 spawnPos = caller.transform.position + positionOffset;
            Quaternion spawnRot=caller.transform.rotation;


            Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, spawnRot);
            if (newBullet == null) return;
            newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
            newBullet.gameObject.SetActive(true);
        }
    }
}
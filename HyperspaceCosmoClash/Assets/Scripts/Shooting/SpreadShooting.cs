using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpreadShooting", menuName = "ScriptableObject/ShootingBehaviour/SpreadShooting")]
public class SpreadShooting : ShootingBehaviour
{
    [SerializeField] protected int bulletCount = 3;
    [SerializeField] protected float spreadAngle = 120f;
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        Vector3 spawnPos = shooterTransform.position;
        Quaternion rotation = shooterTransform.rotation;

        float angleStep = spreadAngle / (bulletCount-1);
        float currentAngle = -spreadAngle/2;
        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, currentAngle);
            //Debug.Log(currentAngle);
            //Debug.Log(rotation * bulletRotation);
            Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation * bulletRotation);
            if (newBullet == null) continue;
            newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
            newBullet.gameObject.SetActive(true);

            currentAngle += angleStep;

        }
    }
}

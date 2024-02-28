using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerNormalShooting", menuName = "ScriptableObject/ShootingBehaviour/PlayerNormalShooting")]
public class PlayerNormalShooting : NormalShooting
{
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        Vector3 spawnPos = shooterTransform.position;
        Quaternion rotation = shooterTransform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
        newBullet.gameObject.SetActive(true);
        newBullet.GetComponent<BulletCtrl>().BulletDamagesender.ChangeDamage(caller.GetComponent<ShipCtrl>().ShipStat.ShipDamage);
        
    }
}

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
        if (newBullet != null && caller != null)
        {
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            if (bulletCtrl != null)
            {
                ShipCtrl shipCtrl = caller.GetComponent<ShipCtrl>();
                if (shipCtrl != null)
                {

                    bulletCtrl.BulletDamagesender.ChangeDamage(shipCtrl.ShipStat.ShipDamage);
                }
            }
        }
    }
}

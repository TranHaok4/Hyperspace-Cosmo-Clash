using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RapidShooting", menuName = "ScriptableObject/ShootingBehaviour/RapidShooting")]

public class RapidShooting : ShootingBehaviour
{
    [SerializeField] protected int numberBullet;
    [SerializeField] protected float timeBetweenShot;
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        caller.StartCoroutine(RapidShoot(shooterTransform, typeBullet));
    }
    protected IEnumerator RapidShoot(Transform shooterTransform,TypeBullet typeBullet)
    {
        for (int i = 0; i < numberBullet; i++)
        {
            Vector3 spawnPos = shooterTransform.position;
            Quaternion rotation = shooterTransform.rotation;
            Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation);
            if (newBullet != null)
            {
                newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
                newBullet.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(timeBetweenShot);
        }
    }
}

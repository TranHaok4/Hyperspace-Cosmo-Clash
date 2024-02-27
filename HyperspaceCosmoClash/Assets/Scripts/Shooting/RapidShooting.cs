using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a shooting behavior that rapidly shoots a specified number of bullets with a given time interval between shots.
/// </summary>
[CreateAssetMenu(fileName = "RapidShooting", menuName = "ScriptableObject/ShootingBehaviour/RapidShooting")]
public class RapidShooting : ShootingBehaviour
{
    [SerializeField] protected int numberBullet;
    [SerializeField] protected float timeBetweenShot;

    /// <summary>
    /// Shoots bullets with the rapid shooting behavior.
    /// </summary>
    /// <param name="caller">The MonoBehaviour instance that initiates the shooting.</param>
    /// <param name="shooterTransform">The transform of the shooter.</param>
    /// <param name="typeBullet">The type of bullet to shoot.</param>
    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        caller.StartCoroutine(RapidShoot(shooterTransform, typeBullet));
    }

    protected IEnumerator RapidShoot(Transform shooterTransform, TypeBullet typeBullet)
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

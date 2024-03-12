using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RapidSpreadShooting", menuName = "ScriptableObject/ShootingBehaviour/RapidSpreadShooting")]
public class RapidSpreadShooting : ShootingBehaviour
{
    [SerializeField] protected int numberBullet;
    [SerializeField] protected int numberShoot;
    [SerializeField] protected float spreadAngle = 120f;
    [SerializeField] protected float timeBetweenShot;



    public override void Shoot(MonoBehaviour caller, Transform shooterTransform, TypeBullet typeBullet)
    {
        caller.StartCoroutine(RapidShoot(shooterTransform, typeBullet));
    }

    protected IEnumerator RapidShoot(Transform shooterTransform, TypeBullet typeBullet)
    {
        for (int i = 0; i < numberShoot; i++)
        {
            Vector3 spawnPos = shooterTransform.position;
            Quaternion rotation = shooterTransform.rotation;

            float angleStep = spreadAngle / (numberBullet-1);
            float currentAngle = -spreadAngle/2;
            for (int j = 0; j < numberBullet; j++)
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
            yield return new WaitForSeconds(timeBetweenShot);
        }
    }
}

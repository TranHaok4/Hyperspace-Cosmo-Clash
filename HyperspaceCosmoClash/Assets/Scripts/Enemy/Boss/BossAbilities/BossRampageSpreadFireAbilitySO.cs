using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossRampageSpreadFire", menuName = "ScriptableObject/BossAbilities/BossRampageSpreadFire")]
public class BossRampageSpreadFireAbilitySO : BossAbilityDataSO
{
    [SerializeField] protected float timeDelayActive;
    [SerializeField] float lastActivationTime = 0;

    [SerializeField] protected bool condition = true;

    [SerializeField] protected int numberOfshoot;
    [SerializeField] protected float timeDelayBetweenFire;
    [SerializeField] protected int numberOfBullet;
    [SerializeField] protected float spreadAngle;
    [SerializeField] protected TypeBullet typeBullet;

    protected  override bool ActivationCondition(GameObject owner)
    {
        if(Time.time-lastActivationTime>=timeDelayActive && condition)
        {
            return true;
        }
        return false;
    }
    public override IEnumerator Activate(GameObject owner)
    {
        lastActivationTime = Time.time;
        condition = true;
        while (true)
        {
            yield return new WaitUntil(() => ActivationCondition(owner));
            DoActivate(owner);
        }
    }
    protected override void DoActivate(GameObject owner)
    {
        lastActivationTime = Time.time;
        owner.GetComponent<MonoBehaviour>().StartCoroutine(RampageSpreadFire(owner.transform, typeBullet));
    }
    protected IEnumerator RampageSpreadFire(Transform shooterTransform, TypeBullet typeBullet)
    {
        for (int i = 0; i < numberOfshoot; i++)
        {
            Vector3 spawnPos = shooterTransform.position;
            Quaternion rotation = shooterTransform.rotation;

            float currentAngle = Random.Range(-spreadAngle/2,spreadAngle/2);
            for (int j = 0; j < numberOfBullet; j++)
            {
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, currentAngle);
                //Debug.Log(currentAngle);
                //Debug.Log(rotation * bulletRotation);
                Transform newBullet = BulletSpawner.Instance.Spawn(typeBullet.ToString(), spawnPos, rotation * bulletRotation);
                if (newBullet == null) continue;
                newBullet.GetComponent<BulletCtrl>().SetShooter(shooterTransform);
                newBullet.gameObject.SetActive(true);

                currentAngle =Random.Range(-spreadAngle/2,spreadAngle/2);
            }
            yield return new WaitForSeconds(timeDelayBetweenFire);
        }
    }
}

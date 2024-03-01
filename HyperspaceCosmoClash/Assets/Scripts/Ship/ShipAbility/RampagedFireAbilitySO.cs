using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RampagedFireAbilitySO", menuName = "ScriptableObject/ShipAbilities/RampagedFireAbilitySO", order = 1)]
public class RampagedFireAbilitySO :AbilityStatSO
{
    [SerializeField] protected int rampageFireCount;
    [SerializeField] protected int numberofBulleteachWave;
    [SerializeField] protected float rampageFireRange;

    public override void ActiveSkill(ShipCtrl shipCtrl)
    {
        if(abilityState==AbilityState.CoolDown)
        {
            return;
        }
        shipCtrl.StartCoroutine(Cooldowning());
        shipCtrl.StartCoroutine(RampageFire(shipCtrl));

    }
    IEnumerator RampageFire(ShipCtrl shipCtrl)
    {
        ObjectShooting shipshooting=  shipCtrl.ShipShooter;
        for (int i = 0; i < rampageFireCount; i++)
        {
            for (int j = 0; j < numberofBulleteachWave; j++)
            {
                // Tìm vector vuông góc
                float rotation = -shipCtrl.transform.eulerAngles.z+90;
                Vector3 direction = new Vector3(Mathf.Sin(rotation * Mathf.Deg2Rad), Mathf.Cos(rotation * Mathf.Deg2Rad));
                Vector3 perpendicularDirection = new Vector3(-direction.y, direction.x);
                Debug.Log(j + " " + direction);
                Debug.Log(j + " " + perpendicularDirection);

                // Tạo vector ngẫu nhiên
                float randomOffset = Random.Range(-rampageFireRange / 2f, rampageFireRange / 2f);
                Vector3 randomPositionOffset = randomOffset * perpendicularDirection;

                // Tính toán randomPosition
                Vector3 randomPosition = shipCtrl.transform.position + randomPositionOffset;
                Quaternion spawnRot=shipCtrl.transform.rotation;

                Transform prefab = BulletSpawner.Instance.Spawn(shipshooting.Bullet.ToString(), randomPosition, spawnRot);
                prefab.gameObject.SetActive(true);

                Debug.Log(j + " " + randomPosition);
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}

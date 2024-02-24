using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSpawnChild", menuName = "ScriptableObject/BossAbilities/BossSpawnChild")]

public class BossSpawnChildAbilitySO : BossAbilityDataSO
{
    [SerializeField] protected float timeDelayActive;
    [SerializeField] protected float lastActivationTime = 0;

    [SerializeField] protected EnemyCtrl childObject;
    [SerializeField] protected int numberChildSpawn;
    [SerializeField] protected int numberChillDespawn;
    [SerializeField] protected bool condition = true;
    protected override bool ActivationCondition(GameObject owner)
    {
        if (Time.time - lastActivationTime >= timeDelayActive && condition)
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
        Debug.Log("kich hoat skill spawn");

        lastActivationTime = Time.time;
        condition = false;
        numberChillDespawn = 0;
        owner.GetComponent<MonoBehaviour>().StartCoroutine(Spawning(owner));
    }
    protected IEnumerator Spawning(GameObject owner)
    {
        for(int i=1;i<=numberChildSpawn;i++)
        {
            float randomx = owner.transform.position.x + Random.Range(-5, 5);
            float randomy = owner.transform.position.y + Random.Range(-5, 5);
            //Debug.Log(randomx + " " + randomy);
            Transform newprefab =EnemySpawner.Instance.Spawn(childObject.name,new Vector3(randomx,randomy,0), owner.transform.rotation);
            newprefab.gameObject.SetActive(true);   
            //Debug.Log(newprefab.transform.position);
            EnemyDespawn newprefabDespawn=newprefab.GetComponent<EnemyCtrl>().Enemydespawn;
            if(newprefabDespawn!=null)
            {
                newprefabDespawn.OnDespawmObjectCallBack += CheckCondition;
            }
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
        }
    }
    protected virtual void CheckCondition()
    {
        numberChillDespawn++;
        if (numberChillDespawn == numberChildSpawn)
        {
            condition = true;
            lastActivationTime = Time.time;
            numberChillDespawn = 0;
        }
    }
}

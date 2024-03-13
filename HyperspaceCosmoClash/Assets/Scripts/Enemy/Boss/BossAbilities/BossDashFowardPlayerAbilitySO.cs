using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossDashFowardPlayer", menuName = "ScriptableObject/BossAbilities/BossDashFowardPlayer")]

public class BossDashFowardPlayerAbilitySO : BossAbilityDataSO
{
    [SerializeField] protected float timeDelayActive;
    [SerializeField] float lastActivationTime = 0;

    [SerializeField] protected bool condition = true;
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashTime;
    [SerializeField] protected int numberOfDash;

    protected override bool ActivationCondition(GameObject owner)
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
        condition = false;
        owner.GetComponent<BossCtrl>().Enemymovement.gameObject.SetActive(false);
        owner.GetComponent<BossCtrl>().Objectshooting.gameObject.SetActive(false);
        owner.GetComponent<MonoBehaviour>().StartCoroutine(DashFowardPlayer(owner));
    }
    protected IEnumerator DashFowardPlayer(GameObject owner)
    {
        Debug.Log("DashFowardPlayer");
        for (int i = 0; i < numberOfDash; i++)
        {
            owner.GetComponent<BossCtrl>().EnemyLookatplayer.SetDisplayLine(true);
            yield return new WaitForSeconds(0.75f);
            float startTime = Time.time;
            owner.GetComponent<BossCtrl>().EnemyLookatplayer.gameObject.SetActive(false);
            Vector3 targetPos = new Vector3();
            targetPos=owner.GetComponent<BossCtrl>().EnemyLookatplayer.PlayerPos.transform.position;
            Vector3 direction = (targetPos - owner.transform.position).normalized;
            float elapsedTime = 0f;
            while (elapsedTime < dashTime)
            {
                float t = elapsedTime / dashTime;

                float easedT = Mathf.SmoothStep(0f, 1f, t); 

                Vector3 dashPosition = owner.transform.position + direction * easedT * dashSpeed * Time.deltaTime;

                owner.transform.position = dashPosition;

                elapsedTime += Time.deltaTime;
                yield return null; 
            }
            owner.GetComponent<BossCtrl>().EnemyLookatplayer.gameObject.SetActive(true);
        }
        owner.GetComponent<BossCtrl>().Enemymovement.gameObject.SetActive(true);
        owner.GetComponent<BossCtrl>().EnemyLookatplayer.SetDisplayLine(false);
        owner.GetComponent<BossCtrl>().Objectshooting.gameObject.SetActive(true);
        ResetSkill();
    }
    protected virtual void ResetSkill()
    {
        lastActivationTime = Time.time;
        Debug.Log(Time.time-lastActivationTime);
        condition = true;
    }
}

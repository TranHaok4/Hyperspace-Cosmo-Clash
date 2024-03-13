using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashForward : EnemyMoveForward
{
    [SerializeField] protected float dashSpeed;
    [SerializeField] protected float dashTime;

    protected override void OnEnable()
    {
        base.Start();
        StartCoroutine(DashForwardPlayer());
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(DashForwardPlayer());
    }
    protected IEnumerator DashForwardPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.75f);
            enemyCtrl.EnemyLookatplayer.SetDisplayLine(true);
            yield return new WaitForSeconds(0.2f);
            enemyCtrl.EnemyLookatplayer.gameObject.SetActive(false);
            Vector3 targetPos = new Vector3();
            targetPos = enemyCtrl.EnemyLookatplayer.PlayerPos.transform.position;
            Vector3 direction = (targetPos - enemyCtrl.transform.position).normalized;
            float elapsedTime = 0f;
            while (elapsedTime < dashTime)
            {
                float t = elapsedTime / dashTime;

                float easedT = Mathf.SmoothStep(0f, 1f, t);

                Vector3 dashPosition = enemyCtrl.transform.position + direction * easedT * dashSpeed * Time.deltaTime;

                transform.parent.position = dashPosition;

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            enemyCtrl.EnemyLookatplayer.gameObject.SetActive(true);
            enemyCtrl.EnemyLookatplayer.SetDisplayLine(false);
        }
    }

    protected override void Moving()
    {
        //
    }
}

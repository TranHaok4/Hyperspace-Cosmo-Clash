using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLazerControl : HaroMonoBehaviour
{
    [SerializeField] protected float toggledelay = 5f;
    [SerializeField] protected bool isToogle = false;

    [SerializeField] protected ObstaclesCtrl obstacleCtrl;
    protected ObstaclesVisual obstaclevisual;
    protected ObstaclesImpart obstaclecollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
    }
    protected virtual void LoadObstacleCtrl()
    {
        if (this.obstacleCtrl != null) return;
        this.obstacleCtrl = transform.parent.GetComponent<ObstaclesCtrl>();
        Debug.Log(transform.name + "LoadObstacleCtrl", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.LoadObtacleComponen();
        if(isToogle) StartCoroutine(ToggleLaserRoutine());
    }

    protected virtual void LoadObtacleComponen()
    {
        obstaclevisual = obstacleCtrl.Obstaclevisual;
        obstaclecollider = obstacleCtrl.ObstacleImpart;
    }
    private IEnumerator ToggleLaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggledelay); 
            ToggleLaser();
        }
    }
    protected void ToggleLaser()
    {
        if (obstaclevisual != null)
        {
            obstaclevisual.gameObject.SetActive(!obstaclevisual.gameObject.activeSelf); 
        }
        if (obstaclecollider != null)
        {
            obstaclecollider.gameObject.SetActive(!obstaclecollider.gameObject.activeSelf);
        }
    }
    public virtual void TurnOffLazer()
    {
        if (obstaclevisual != null)
        {
            obstaclevisual.gameObject.SetActive(false);
        }
        if (obstaclecollider != null)
        {
            obstaclecollider.gameObject.SetActive(false);
        }
    }
}

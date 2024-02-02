using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLazerControl : HaroMonoBehaviour
{
    [SerializeField] protected float toggledelay = 5f;
    [SerializeField] protected bool isToogle = false;

    [SerializeField] protected ObstaclesCtrl obstacleCtrl;
    [SerializeField] protected ObstaclesVisual obstaclevisual;
    [SerializeField] protected ObstaclesImpart obstaclecollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObstacleCtrl();
        this.LoadObtacleComponent();
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
        this.LoadObtacleComponent();
        if(isToogle) StartCoroutine(ToggleLaserRoutine());
    }

    protected virtual void LoadObtacleComponent()
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
        Debug.Log(transform.parent.name);
        if (obstaclevisual != null)
        {
            //Debug.Log(transform.parent.name+":tat visual");
            obstaclevisual.gameObject.SetActive(false);
        }
        if (obstaclecollider != null)
        {
            obstaclecollider.gameObject.SetActive(false);
        }
    }
    public virtual void TurnOnLazer()
    {
        if (obstaclevisual != null)
        {
            obstaclevisual.gameObject.SetActive(true);
        }
        if (obstaclecollider != null)
        {
            obstaclecollider.gameObject.SetActive(true);
        }
    }
}

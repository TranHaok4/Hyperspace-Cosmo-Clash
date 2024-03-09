using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : HaroMonoBehaviour
{
    [SerializeField] protected Transform point1;
    [SerializeField] protected Transform point2;
    [SerializeField] protected float timedelayTele=5f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTeleportPoint();
    }
    protected virtual void LoadTeleportPoint()
    {
        if (point1 == null)
        {
            point1 = transform.Find("Point1");
        }
        if (point2 == null)
        {
            point2 = transform.Find("Point2");
        }
    }
    protected virtual void Update()
    {
        if (timedelayTele>0)
        {
            timedelayTele-=Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("TeleportPoint: OnTriggerEnter2D");
        if (other.transform.parent.gameObject.CompareTag("Player")) 
        {
            Debug.Log("TeleportPoint: OnTriggerEnter2D");
            Transform destination;
            float dis1=Vector3.Distance(other.transform.parent.gameObject.transform.position,point1.position);
            float dis2=Vector3.Distance(other.transform.parent.gameObject.transform.position,point2.position);
            if (dis1<dis2)
            {
                destination = point2;
            }
            else
            {
                destination = point1;
            }
            if(timedelayTele<=0)
            {
                timedelayTele=5f;
                other.transform.parent.gameObject.transform.position = destination.position;
            }
        }
    }


}

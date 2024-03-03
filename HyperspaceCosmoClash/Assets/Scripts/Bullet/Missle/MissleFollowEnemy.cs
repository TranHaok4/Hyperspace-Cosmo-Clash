using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CircleCollider2D))]
public class MissleFollowEnemy : HaroMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected float rangeOfDetection = 5f;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float moveForwardSpeed = 3f;


    void OnValidate()
    {
        this.circleCollider2D.radius = rangeOfDetection;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = rangeOfDetection;
        Debug.Log(transform.name + "LoadCircleCollider2D", gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("MissleFollowEnemy: OnTriggerEnter2D: " + other.gameObject.name, gameObject);
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Debug.Log("MissleFollowEnemy: OnTriggerEnter2D: " + other.gameObject.name, gameObject);
            if(this.target == null )
            {
                this.target = other.transform;
            }
            else if(this.target.parent.gameObject.activeSelf == false)
            {
                this.target = other.transform;
            }
        }
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            // Find a new target or continue flying in the current direction
            MoveForward();
        }
        else
        {
            // Follow the current target
            MoveTowardsTarget();
        }
    }

    protected virtual void FindNewTarget()
    {
        // Find the closest enemy within the range of detection
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rangeOfDetection);
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = collider.transform;
                }
            }
        }
        this.target = closestTarget;
    }

    protected virtual void MoveTowardsTarget()
    {
        //Debug.Log(target.transform.name+":"+target.parent.gameObject.activeSelf);
        if (target.parent.gameObject.activeSelf == false)
        {
            FindNewTarget();
            MoveForward();
            return;
        }

        Vector2 direction = (target.position - transform.parent.position).normalized;
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float timeSpeed = 5 * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
        //Vector3 newpos = Vector3.Lerp(transform.parent.position, target.position, this.speed*Time.deltaTime);
        transform.parent.position += transform.right * speed * Time.deltaTime;
    }
    protected virtual void MoveForward()
    {
        transform.parent.Translate(Vector3.right * this.moveForwardSpeed * Time.deltaTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : HaroMonoBehaviour
{
    [SerializeField] protected TypeBullet bullet;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;


    // ổ đây tôi muốn có một giá trị mà dev có thể chọn một kiểu bắn đạn như là enum
    //nếu chọn normal shoot thì ko có gì thay đổi
    // nếu chọn rapid shoot thì sẽ có thêm thông số về số lượng đạn bắn ra 

    protected void Update()
    {
        this.IsShooting();
    }
    protected void FixedUpdate()
    {
        this.Shooting();
    }
    

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer <= this.shootDelay) return;
        this.shootTimer = 0;
        this.Shoot();//ở đây sẽ áp dụng loại shoot được chọn
    }
    protected abstract void Shoot();
    protected abstract bool IsShooting();
}

public enum TypeBullet
{
    none=0,
    PlayerBullet=1,
    EnemyBullet=2,
}
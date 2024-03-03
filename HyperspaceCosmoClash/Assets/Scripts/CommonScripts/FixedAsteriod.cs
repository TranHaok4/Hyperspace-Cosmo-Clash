using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a fixed asteroid in the game.
/// </summary>
public class FixedAsteriod : HaroMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==LayerMask.NameToLayer("EnemyBullet") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            //Debug.Log(collision.name);
            BulletCtrl bulletOBJ = collision.gameObject.transform.parent.GetComponent<BulletCtrl>();
            if(bulletOBJ != null)
            {
                bulletOBJ.BulletDespawn.DespawnObject();
            }
            else
            {
                Debug.Log("haha");
            }
        }
    }
}

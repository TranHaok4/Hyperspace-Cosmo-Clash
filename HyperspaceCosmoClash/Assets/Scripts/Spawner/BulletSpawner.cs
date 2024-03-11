using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns bullets in the game.
/// </summary>
public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    public static string bulletOne = "Bullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;
    }
}

/// <summary>
/// Represents the type of a bullet.
/// </summary>
public enum TypeBullet
{
    none = 0,
    RedPlayerBullet = 1,
    RedBulletNormalEnemyBullet = 2,
    CircleRedEnemyBullet=3,
    SuperTurleBullet=4,
    GreenPlayerBullet = 5,
    RedSniperBullet,
    GreenEnemyMissleBullet,

}

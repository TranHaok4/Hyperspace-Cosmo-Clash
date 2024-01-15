using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLevelManager : HaroMonoBehaviour
{
    private static PlayerLevelManager instance;
    public static PlayerLevelManager Instance { get => instance; }

    [SerializeField] protected LevelDataSO levelDataStats;
    [SerializeField] protected int currentLevel;
    [SerializeField] protected int currentExp=0;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerLevelManager.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        PlayerLevelManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        currentLevel = 1;
        NotifyExpandLevelPlayerShip();
    }

    public virtual void AddExp(int value)
    {
        currentExp += value;
        if (currentExp >= levelDataStats.LevelDataUpgrade[currentLevel])
        {
            currentExp -= levelDataStats.LevelDataUpgrade[currentLevel];
            currentLevel += 1;
        }

        if (currentLevel > levelDataStats.LevelDataUpgrade.Count - 1)
        {
            currentLevel = levelDataStats.LevelDataUpgrade.Count - 1;
            currentExp = levelDataStats.LevelDataUpgrade[currentLevel];

        }
        NotifyExpandLevelPlayerShip();
    }
    
    protected virtual void NotifyExpandLevelPlayerShip()
    {
        ExpShipPlayerNotificater.Instance.OnUpdateExpPlayerShipData(currentExp, levelDataStats.LevelDataUpgrade[currentLevel]);
        ExpShipPlayerNotificater.Instance.OnUpdateLevelPlayerShipData(currentLevel);
    }
}

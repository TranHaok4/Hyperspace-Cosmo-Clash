using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLevelManager : HaroMonoBehaviour
{
    private static PlayerLevelManager instance;
    public static PlayerLevelManager Instance { get => instance; }

    [SerializeField] protected LevelDataSO levelDataStats;
    [SerializeField] protected int currentLevel;
    [SerializeField] protected int currentExp;
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
    }

    public virtual void AddExp(int value)
    {
        if((currentExp+value)>=levelDataStats.LevelDataUpgrade[currentLevel])
        {
            CheckCurrentLevel();
        }
        currentExp += value;
    }
    protected virtual void CheckCurrentLevel()
    {
        if (currentLevel >= levelDataStats.LevelDataUpgrade.Count - 1)
        {
            currentExp = levelDataStats.LevelDataUpgrade[currentLevel];
        }

        if(currentExp>=levelDataStats.LevelDataUpgrade[currentLevel])
        {
            currentExp -= levelDataStats.LevelDataUpgrade[currentLevel];
            currentLevel += 1;
        }
    }
}

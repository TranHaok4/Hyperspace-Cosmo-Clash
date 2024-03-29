using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the level and experience of the player's ship.
/// </summary>
public class PlayerLevelManager : HaroMonoBehaviour
{
    private static PlayerLevelManager instance;
    public static PlayerLevelManager Instance { get => instance; }

    [SerializeField] protected LevelDataSO levelDataStats;
    [SerializeField] protected int currentLevel=1;
    [SerializeField] protected int currentExp=0;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerLevelManager.instance != null) Debug.LogError("Only 1 PlayerLevelManager allow to exist");
        PlayerLevelManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        //Debug.Log("day la ham start ma");
        NotifyChangeInExpPlayerShip();
        NotifyChangeInPlayerShipLevel();
    }

    /// <summary>
    /// Adds the specified amount of experience points to the player's current experience.
    /// If the current experience exceeds the required experience for the current level,
    /// the player's level is increased and the appropriate callbacks are invoked.
    /// </summary>
    /// <param name="value">The amount of experience points to add.</param>
    public virtual void AddExp(int value)
    {
        currentExp += value;
        if (currentExp >= levelDataStats.LevelDataUpgrade[currentLevel])
        {
            currentExp -= levelDataStats.LevelDataUpgrade[currentLevel];
            currentLevel += 1;
            //Debug.Log(currentLevel);
            NotifyChangeInPlayerShipLevel();
        }

        if (currentLevel > levelDataStats.LevelDataUpgrade.Count - 1)
        {
            currentLevel = levelDataStats.LevelDataUpgrade.Count - 1;
            currentExp = levelDataStats.LevelDataUpgrade[currentLevel];

        }
        NotifyChangeInExpPlayerShip();
    }
    
    protected virtual void NotifyChangeInExpPlayerShip()
    {
        //Debug.Log(currentExp+" "+levelDataStats.LevelDataUpgrade[currentLevel]);
        LevelExpShipPlayerNotificater.Instance.OnUpdateExpPlayerShipData(currentExp, levelDataStats.LevelDataUpgrade[currentLevel]);
    }

    protected virtual void NotifyChangeInPlayerShipLevel()
    {
        LevelExpShipPlayerNotificater.Instance.OnUpdateLevelPlayerShipData(currentLevel);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Represents a ScriptableObject that holds level data and upgrades.
/// </summary>
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] protected List<int> levelDataUpagrade;

    /// <summary>
    /// Gets the list of level data upgrades.
    /// </summary>
    public List<int> LevelDataUpgrade { get => levelDataUpagrade; }
}

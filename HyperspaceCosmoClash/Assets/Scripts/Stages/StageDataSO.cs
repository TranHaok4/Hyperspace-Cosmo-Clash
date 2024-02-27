using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a ScriptableObject that holds data for a stage in the game.
/// </summary>
[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObject/StageData")]
public class StageDataSO : ScriptableObject
{
    [System.Serializable]
    public struct EnemyCondition
    {
        [SerializeField] public EnemyName name;
        [SerializeField] public int numberEnemy;
    }
    
    [SerializeField] protected List<EnemyCondition> conditions;
    
    /// <summary>
    /// Gets the list of enemy conditions for this stage.
    /// </summary>
    public List<EnemyCondition> Conditions { get => conditions; }
}

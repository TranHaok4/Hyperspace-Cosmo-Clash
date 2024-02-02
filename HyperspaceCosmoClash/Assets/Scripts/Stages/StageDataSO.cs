using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<EnemyCondition> Conditions { get => conditions; }
}

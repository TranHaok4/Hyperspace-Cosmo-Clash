using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObject/LevelData")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] protected List<int> levelDataUpagrade;

    public List<int> LevelDataUpgrade { get => levelDataUpagrade; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseDamageEnhanceSO", menuName = "ScriptableObject/Enhancement/IncreaseDamageEnhanceSO")]
public class IncreaseDamageEnhanceSO : EnhancementDataSO
{
    public override void ApplyEnhancement()
    {
        Debug.Log("Da increase Damage");
    }
}

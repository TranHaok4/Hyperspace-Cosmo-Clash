using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a scriptable object for storing experience item profile data.
/// </summary>
[CreateAssetMenu(fileName = "ExpData", menuName = "ScriptableObject/ExpData")]
public class ExpItemProfileSO : ItemProfileSO
{
    [SerializeField] protected int minExpValue;
    [SerializeField] protected int maxExpValue;

    /// <summary>
    /// Gets a random experience value within the specified range.
    /// </summary>
    /// <returns>The randomly generated experience value.</returns>
    public virtual int GetExpValue()
    {
        int kq = (int)Random.Range(minExpValue, maxExpValue);
        //Debug.Log(kq);    
        return kq;
    }
}

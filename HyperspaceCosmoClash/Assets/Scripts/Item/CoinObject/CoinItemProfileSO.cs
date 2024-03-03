using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a scriptable object for storing data related to a coin item profile.
/// </summary>
[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObject/CoinData")]
public class CoinItemProfileSO : ItemProfileSO
{
    [SerializeField] protected int value;

    /// <summary>
    /// Gets the value of the coin item.
    /// </summary>
    public int Value { get => value; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObject/CoinData")]
public class CoinItemProfileSO : ItemProfileSO
{
    [SerializeField] protected int value;

    public int Value { get => value; }
}

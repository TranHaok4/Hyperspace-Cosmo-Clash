using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExpData", menuName = "ScriptableObject/ExpData")]
public class ExpItemProfileSO : ScriptableObject
{
    [SerializeField] protected int minExpValue;
    [SerializeField] protected int maxExpValue;

    public virtual int GetExpValue()
    {
        int kq= (int)Random.Range(minExpValue, maxExpValue);
        //Debug.Log(kq);
        return kq;
    }
}

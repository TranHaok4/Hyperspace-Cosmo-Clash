using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHUD : HaroMonoBehaviour
{
    protected virtual IEnumerator WaitForConditionThenExecute()
    {
        yield return null;
    }
}

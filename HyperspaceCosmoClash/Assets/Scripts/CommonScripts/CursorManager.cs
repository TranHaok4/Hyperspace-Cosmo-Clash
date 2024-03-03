using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager :HaroMonoBehaviour
{
    [SerializeField] protected Texture2D defaultCursorTexture;
    [SerializeField] protected Texture2D clickCursorTexture;

    protected override void Start()
    {
        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        InputManager.Instance.OnFiringChange += ChangeCursorShoot;
    }

    protected virtual void ChangeCursorShoot(int onFiring)
    {
        if (onFiring == 1)
        {
            Cursor.SetCursor(clickCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}

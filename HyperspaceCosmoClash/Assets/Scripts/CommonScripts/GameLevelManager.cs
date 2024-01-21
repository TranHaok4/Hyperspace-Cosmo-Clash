using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLevelManager : HaroMonoBehaviour
{
    private static GameLevelManager instance;
    public static GameLevelManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if(GameLevelManager.instance!=null && GameLevelManager.instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameLevelManager.instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public virtual void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public virtual void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Manages the game level and provides utility methods for loading scenes and exiting the game.
/// </summary>
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

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public virtual void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public virtual void ExitGame()
    {
        Application.Quit();
    }
}

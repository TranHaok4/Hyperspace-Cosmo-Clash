using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the game music in different scenes.
/// </summary>
public class GameMusicManager : HaroMonoBehaviour
{
    [SerializeField] protected SceneMusicDataSO musicDataSO;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected SceneType currentSceneType;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        if (audioSource != null) return;
        this.audioSource = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + "LoadAudioSource", gameObject);
    }
    private static GameMusicManager instance;
    public static GameMusicManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (GameMusicManager.instance != null && GameMusicManager.instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameMusicManager.instance = this;
            DontDestroyOnLoad(this);
        }
    }
    protected void PlayMusicForScene(SceneType sceneType)
    {
        //if (currentSceneType != sceneType)
        {
            currentSceneType = sceneType;
            var musicList = musicDataSO.sceneMusicList.Find(sceneMusic => sceneMusic.scene == sceneType)?.musicClips;
            if (musicList != null && musicList.Count > 0)
            {
                audioSource.clip = musicList[0]; 
                audioSource.Play();
            }
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneType loadedSceneType = GetSceneTypeFromName(scene.name);
        GameMusicManager.Instance.PlayMusicForScene(loadedSceneType);
    }
    SceneType GetSceneTypeFromName(string sceneName)
    {
        switch (sceneName)
        {
            case "GameMenuScene":
                return SceneType.GameMenuScene;
            case "PrototypeScene":
                return SceneType.PrototypeScene;
            case "Map1":
                return SceneType.Map1;
            default:
                return SceneType.GameMenuScene; 
        }
    }
    protected override void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForInstanceScene();
    }

    public virtual void PlayAnotherMusic(AudioClip musicClip)
    {
        audioSource.clip = musicClip;
        audioSource.Play();
    }
    public virtual void PlayMusicForInstanceScene()
    {
        Debug.Log("PlayMusicForInstanceScene");
        PlayMusicForScene(GetSceneTypeFromName(SceneManager.GetActiveScene().name));  
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

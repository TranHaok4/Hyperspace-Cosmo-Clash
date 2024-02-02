using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneMusicData", menuName = "ScriptableObject/Audio/SceneMusicData", order = 1)]

public class SceneMusicDataSO : ScriptableObject
{
    [System.Serializable]
    public class SceneMusic
    {
        [SerializeField] public SceneType scene;
        [SerializeField] public List<AudioClip> musicClips;
    }

    public List<SceneMusic> sceneMusicList;
}

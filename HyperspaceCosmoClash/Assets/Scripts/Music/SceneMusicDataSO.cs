using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneMusicData", menuName = "ScriptableObject/SceneMusicData", order = 1)]

public class SceneMusicDataSO : ScriptableObject
{
    [System.Serializable]
    public class SceneMusic
    {
        public SceneType scene;
        public List<AudioClip> musicClips;
    }

    public List<SceneMusic> sceneMusicList;
}

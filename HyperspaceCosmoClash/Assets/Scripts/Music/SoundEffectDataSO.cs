using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundEffectData", menuName = "ScriptableObject/Audio/SoundEffectData", order = 1)]
public class SoundEffectDataSO : ScriptableObject
{
    [SerializeField] protected SoundFXName soundname;
    public SoundFXName SoundName { get => soundname; }

    [SerializeField] protected AudioClip clip;
    public AudioClip Clip { get => clip; }

    [SerializeField] protected float volume = 1f;
    public float Volume { get => volume; }

    [SerializeField] protected float pitch = 1f;
    [SerializeField] protected bool loop = false;
}

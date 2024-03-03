using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the audio in the game, including playing sound effects.
/// </summary>
public class AudioManager : HaroMonoBehaviour
{
    [SerializeField] protected List<SoundEffectDataSO> soundEffects;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (AudioManager.instance != null && AudioManager.instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(this);
        }
    }

    /// <summary>
    /// Plays a sound effect at the specified position and rotation.
    /// </summary>
    /// <param name="name">The name of the sound effect to play.</param>
    /// <param name="pos">The position at which to play the sound effect.</param>
    /// <param name="rot">The rotation at which to play the sound effect.</param>
    public virtual void PlaySound(SoundFXName name, Vector3 pos, Quaternion rot)
    {
        SoundEffectDataSO soundeffect = GetAudio(name);
        Transform newSFX = SFXSpawner.Instance.Spawn(pos, rot);
        AudioSource audioSource = newSFX.gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundeffect.Clip;
        audioSource.volume = soundeffect.Volume;
        newSFX.gameObject.SetActive(true);
        audioSource.Play();
    }

    protected virtual SoundEffectDataSO GetAudio(SoundFXName name)
    {
        foreach (SoundEffectDataSO sfx in soundEffects)
        {
            if (sfx.SoundName == name)
            {
                return sfx;
            }
        }
        return null;
    }
}

public enum SoundFXName
{
    none=0,
    playershoot=1,
    enemyshoot=2,
    enemyExplosion=3,
    meteoriteExplosion=4,
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public virtual void PlaySound(SoundFXName name,Vector3 pos,Quaternion rot)
    {
        SoundEffectDataSO soundeffect = GetAudio(name);
        Transform newSFX = SFXSpawner.Instance.Spawn(pos, rot);
        AudioSource audioSource = newSFX.gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundeffect.Clip;
        audioSource.volume = soundeffect.Volume;
        newSFX.gameObject.SetActive(true);
    }
    protected virtual SoundEffectDataSO GetAudio(SoundFXName name)
    {
        foreach(SoundEffectDataSO sfx in soundEffects)
        {
            if(sfx.SoundName==name)
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
}

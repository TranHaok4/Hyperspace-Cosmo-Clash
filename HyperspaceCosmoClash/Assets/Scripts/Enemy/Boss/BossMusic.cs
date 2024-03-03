using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : HaroMonoBehaviour
{
    [SerializeField] protected AudioClip bossAudioClip;
    public AudioClip BossAudioClip { get => bossAudioClip; }

    [SerializeField] protected BossCtrl bossCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossCtrl();
    }
    protected virtual void LoadBossCtrl()
    {
        if (bossCtrl != null) return;
        this.bossCtrl = transform.parent.GetComponent<BossCtrl>();
        Debug.Log(transform.name + "LoadBossCtrl", gameObject);
    }

        protected override void OnEnable()
        {
            base.OnEnable();
            IEnumerator ActivateAfterDelay(float delay)
            {
                yield return new WaitForSeconds(delay);
                GameMusicManager.Instance.PlayAnotherMusic(bossAudioClip);
            }

            StartCoroutine(ActivateAfterDelay(1.5f));
        }

        protected override void OnDisable()
        {
            GameMusicManager.Instance.PlayMusicForInstanceScene();
        }
    }
